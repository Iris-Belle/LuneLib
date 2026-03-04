namespace LuneLib.Core.Config;

public class Client : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("Client")]

    [DefaultValue(false)]
    public bool DebugMessages { get; set; }

    [DefaultValue(true)]
    public bool dayshelptext { get; set; }

    [DefaultValue(true)]
    public bool Days { get; set; }

    public override void OnLoaded() => clientConfig = this;
}