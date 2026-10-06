namespace LuneLib.Core.Config;

public class Client : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("Client")]

    [DefaultValue(true)]
    public bool DaysHelpText { get; set; }

    [DefaultValue(true)]
    public bool Days { get; set; }

    public override void OnLoaded() => _ClientConfig = this;
}