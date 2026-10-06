namespace LuneLib; // built for tML v2026.8.3.0 on 06-10-2026

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class RoundNumberAttribute : CustomModConfigItemAttribute
{
    public int DecimalPlaces { get; }
    public RoundNumberAttribute(int decimalplaces) : base(typeof(RoundNumber)) => DecimalPlaces = decimalplaces;
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
public class ColourPaletteAttribute : Attribute { }

public class RoundNumber : FloatElement
{
    public override void OnBind()
    {
        base.OnBind();
        int decimalplaces = MemberInfo.MemberInfo.GetCustomAttribute<RoundNumberAttribute>().DecimalPlaces;
        string label = Label;

        TextDisplayFunction = () =>
        {
            float num = (float)GetObject();
            string fixedlabel = num.ToString($"F{decimalplaces}", CultureInfo.InvariantCulture);
            if (fixedlabel.Contains('.')) fixedlabel = fixedlabel.TrimEnd('0').TrimEnd('.');
            if (fixedlabel == "-0") fixedlabel = "0";
            return $"{label}: {fixedlabel}";
        };
    }
}

public class ColourPaletteHook : ILoadable
{

    #region Fields/Properties

    const byte PageAlpha = 200;
    const byte ItemAlpha = 255;
    static readonly ConditionalWeakTable<object, Start> Colored = [];
    static readonly FieldInfo backgroundfield = typeof(ConfigElement).GetField("backgroundColor", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    
    public delegate Tuple<UIElement, UIElement> OrigWrapIt(UIElement parent, ref int top, PropertyFieldWrapper memberInfo, object item, int order, object list, Type arrayType, int index);
    public delegate Tuple<UIElement, UIElement> WrapItHook(OrigWrapIt orig, UIElement parent, ref int top, PropertyFieldWrapper memberInfo, object item, int order, object list, Type arrayType, int index);
    
    public delegate UIPanel OrigMakePanel(object item, object subitem, PropertyFieldWrapper memberInfo, IList array, int index, Func<string> abridgedTextDisplayFunction);
    public delegate UIPanel MakePanelHook(OrigMakePanel orig, object item, object subitem, PropertyFieldWrapper memberInfo, IList array, int index, Func<string> abridgedTextDisplayFunction);

    static readonly Color[] Palette =
    [
        new(180, 215, 255), 
        new(145, 185, 230), 
        new(110, 155, 200),
        new(80, 125, 175),  
        new(55, 105, 155),  
        new(35, 80, 130),
        new(20, 60, 105),   
        new(0, 30, 60),     
        new(0, 20, 40),
    ];

    #endregion

    #region Constructors

    class Start
    {
        public Color Colour;
        public bool HasColour;
        public bool IsStart;
        public Dictionary<string, int> BookPage = [];

        public int IndexFor(string name)
        {
            if (!BookPage.TryGetValue(name, out int i))
            {
                i = BookPage.Count;
                BookPage[name] = i;
            }
            return i;
        }
    }

    #endregion

    #region Hooks/Delegates

    public void Load(Mod mod)
    {
        Assembly tmoadloader = typeof(ConfigElement).Assembly;
        Type _UIModConfig = null;

        foreach (Type type in tmoadloader.GetTypes())
        {
            if (type.Name == "UIModConfig")
            {
                _UIModConfig = type;
                break;
            }
        }

        MethodInfo panel = _UIModConfig.GetMethod("MakeSeparateListPanel", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        MethodInfo wrap = _UIModConfig.GetMethod("WrapIt", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        MonoModHooks.Add(wrap, (WrapItHook)WrapItDetour);
        MonoModHooks.Add(panel, (MakePanelHook)MakePanelDetour);
    }
    public void Unload() { }

    private static UIPanel MakePanelDetour(OrigMakePanel orig, object item, object subitem, PropertyFieldWrapper memberInfo, IList array, int index, Func<string> abridged)
    {
        UIPanel panel = orig(item, subitem, memberInfo, array, index, abridged);

        if (subitem != null && Colored.TryGetValue(subitem, out Start entry) && !entry.IsStart)
            panel.BackgroundColor = new Color(entry.Colour.R, entry.Colour.G, entry.Colour.B, PageAlpha);

        return panel;
    }

    private static Tuple<UIElement, UIElement> WrapItDetour(OrigWrapIt orig, UIElement parent, ref int top, PropertyFieldWrapper memberInfo, object item, int order, object list, Type arrayType, int index)
    {
        Color? colour = null;
        bool isClass = IsPageType(memberInfo.Type);
        bool isPage = isClass && IsSeparatePage(memberInfo);
        if (list == null && item != null)
        {
            if (!Colored.TryGetValue(item, out _) && Attribute.IsDefined(item.GetType(), typeof(ColourPaletteAttribute), true))
            {
                Colored.Add(item, new Start { IsStart = true });
            }
            if (Colored.TryGetValue(item, out Start parentEntry))
            {
                if (isPage)
                {
                    int i = parentEntry.IndexFor(memberInfo.Name);
                    Color c = Palette[Math.Min(i, Palette.Length - 1)];
                    colour = new Color(c.R, c.G, c.B, PageAlpha);
                    Register(memberInfo, item, new Start { Colour = c, HasColour = true });
                }
                else if (parentEntry.HasColour)
                {
                    Color c = parentEntry.Colour;
                    colour = new Color(c.R, c.G, c.B, ItemAlpha);
                    if (isClass) Register(memberInfo, item, new Start { Colour = c, HasColour = true });
                }
            }
            else if (isPage && Attribute.IsDefined(memberInfo.MemberInfo, typeof(ColourPaletteAttribute)))
            {
                var root = new Start { IsStart = true };
                var bg = (BackgroundColorAttribute)Attribute.GetCustomAttribute(memberInfo.MemberInfo, typeof(BackgroundColorAttribute));
                if (bg != null)
                {
                    root.Colour = bg.Color;
                    root.HasColour = true;
                }

                Register(memberInfo, item, root);
            }
            else if (isPage && Attribute.IsDefined(memberInfo.MemberInfo, typeof(ColourPaletteAttribute)))
            {
                Register(memberInfo, item, new Start { IsStart = true });
            }
        }
        var result = orig(parent, ref top, memberInfo, item, order, list, arrayType, index);
        if (colour != null && result?.Item2 is ConfigElement element)
            backgroundfield?.SetValue(element, colour.Value);
        return result;
    }

    #endregion

    #region Methods

    private static bool IsSeparatePage(PropertyFieldWrapper member) => Attribute.IsDefined(member.MemberInfo, typeof(SeparatePageAttribute)) || Attribute.IsDefined(member.Type, typeof(SeparatePageAttribute), true);
    private static bool IsPageType(Type type) => type.IsClass && type != typeof(string) && !type.IsArray && !type.IsGenericType && type.Namespace != "Terraria.ModLoader.Config";

    private static void Register(PropertyFieldWrapper memberInfo, object item, Start entry)
    {
        object value = null;
        try
        {
            value = memberInfo.GetValue(item);
        }
        catch
        {
            throw new Exception($"LuneLib.Config.cs (Register(PropertyFieldWrapper memberInfo, object item, Entry entry)): {memberInfo.Name} in {item.GetType().FullName}");
        }

        if (value != null && !value.GetType().IsValueType && value is not string)
            Colored.AddOrUpdate(value, entry);
    }

    #endregion
}