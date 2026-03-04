namespace LuneLib.Core.Config;

public class Debug : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("Debug")]

    [DefaultValue(false)]
    [ReloadRequired]
    public bool TestMode { get; set; }

    [DefaultValue(false)]
    [ReloadRequired]
    public bool CheckIris { get; set; }

    [DefaultValue(false)]
    [ReloadRequired]
    public bool CheckMushy { get; set; }

    [DefaultValue(false)]
    [ReloadRequired]
    public bool CheckNotGoldArc { get; set; }

    public override void OnLoaded() => debug = this;
}