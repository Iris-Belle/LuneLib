namespace LuneLib;

public partial class LuneLib : Mod
{
    public static LuneLib instance;
    public static Debug debug;
    public static Client clientConfig;
    public static Server serverConfig;
    public static CSteamID steamID;
    public bool
        LuneLibAssetsLoaded,
        CalamityModLoaded,
        InfernumModeLoaded,
        CalValExLoaded,
        CalamitasMommyLoaded,
        ThoriumModLoaded,
        VanillaQoLLoaded,
        SpiritModLoaded,
        StrongerReforgesLoaded,
        BrighterLightLoaded,
        CoyoteframesLoaded,
        ChatSourceLoaded,
        DarkSurfaceLoaded;

    public override void Load()
    {
        ClaimROT(0, "day message count", "LuneLib");
        ClaimROT(1, "day message drowsy", "LuneLib");
        ClaimROT(2, "day message the reset1", "LuneLib");
        ClaimROT(3, "day message set day1", "LuneLib");
        ClaimROT(4, "LuneWol Drowning logic", "LuneLib.LuneWOL");
        steamID = SteamUser.GetSteamID();
        instance = this;
        LuneLibAssetsLoaded = ModLoader.HasMod("LuneLibAssets");
        CalamityModLoaded = ModLoader.HasMod("CalamityMod");
        InfernumModeLoaded = ModLoader.HasMod("InfernumMode");
        CalValExLoaded = ModLoader.HasMod("CalValEx");
        CalamitasMommyLoaded = ModLoader.HasMod("CalamitasMommy");
        ThoriumModLoaded = ModLoader.HasMod("ThoriumMod");
        VanillaQoLLoaded = ModLoader.HasMod("VanillaQoL");
        SpiritModLoaded = ModLoader.HasMod("SpiritMod");
        StrongerReforgesLoaded = ModLoader.HasMod("StrongerReforges");
        BrighterLightLoaded = ModLoader.HasMod("BrighterLight");
        CoyoteframesLoaded = ModLoader.HasMod("Coyoteframes");
        ChatSourceLoaded = ModLoader.HasMod("ChatSource");
        DarkSurfaceLoaded = ModLoader.HasMod("DarkSurface");
        if (debug.CheckIris)
        { On_PlayerEyeHelper.SetStateByPlayerInfo += PlayerEyeHelper_SetStateByPlayerInfo; }
    }

    public override void Unload()
    {
        ClearROTClaims();
        ResetROTAll();
        instance = null;
        debug = null;
        clientConfig = null;
        serverConfig = null;
    }

    private void PlayerEyeHelper_SetStateByPlayerInfo(On_PlayerEyeHelper.orig_SetStateByPlayerInfo orig, ref PlayerEyeHelper self, Player player)
    {
        orig(ref self, player);
        if (IrisPlayer)
        {
            if (!player.Submerged())
                self.SwitchToState(EyeState.IsBlind);
            else
                self.SwitchToState(EyeState.NormalBlinking);
        }
    }
}
