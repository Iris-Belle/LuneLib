namespace LuneLib.Core.Config;

public class Server : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("Silly")]

    [DefaultValue(true)]
    public bool FreddyFiveBear { get; set; }

    public override void OnLoaded() => serverConfig = this;
}