namespace LuneLib;

public partial class LuneLib : Mod
{
    public static LuneLib instance;
    internal static Client _ClientConfig;
    internal static Server _ServerConfig;

    public bool
        LuneLibAssetsLoaded,
        LuneWoLLoaded,
        CalamityModLoaded,
        InfernumModeLoaded,
        CalValExLoaded,
        ThoriumModLoaded,
        VanillaQoLLoaded,
        SpiritModLoaded,
        StrongerReforgesLoaded,
        BrighterLightLoaded,
        CoyoteframesLoaded,
        ChatSourceLoaded,
        MagicStorageLoaded,
        MagicStorageVoidBagLoaded,
        DarkSurfaceLoaded;

    public override void Load()
    {
        instance = this;
        LuneLibAssetsLoaded = ModLoader.HasMod("LuneLibAssets");
        LuneWoLLoaded = ModLoader.HasMod("LuneWoL");
        CalamityModLoaded = ModLoader.HasMod("CalamityMod");
        InfernumModeLoaded = ModLoader.HasMod("InfernumMode");
        CalValExLoaded = ModLoader.HasMod("CalValEx");
        ThoriumModLoaded = ModLoader.HasMod("ThoriumMod");
        VanillaQoLLoaded = ModLoader.HasMod("VanillaQoL");
        SpiritModLoaded = ModLoader.HasMod("SpiritMod");
        StrongerReforgesLoaded = ModLoader.HasMod("StrongerReforges");
        BrighterLightLoaded = ModLoader.HasMod("BrighterLight");
        ChatSourceLoaded = ModLoader.HasMod("ChatSource");
        MagicStorageLoaded = ModLoader.HasMod("MagicStorage");
        MagicStorageVoidBagLoaded = ModLoader.HasMod("MagicStorageVoidBag");
        DarkSurfaceLoaded = ModLoader.HasMod("DarkSurface");
    }

    public override void Unload()
    {
        instance = null;
        _ClientConfig = null;
        _ServerConfig = null;
    }
}
