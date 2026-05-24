namespace LuneLib.Common.Players.LuneLibPlayer;

public partial class LibPlayer : ModPlayer
{
    public bool SpaceVacuum = false; // In-space debuff
    public bool BlizzardFrozen = false; //Frozen Blizzard
    public bool Chilly = false; //in tundra
    public bool CrimtuptionzoneNight = false; // In crimtuption during night
    public bool WaterEyes = false; // used for darker waters
    public bool StormEyeCovered = false; // i think this is for the blizzard and or the sandstorm
    public bool IrisSpiritPet = false; // Custom pet
    public bool IsIris = false; // self explanatory

    public bool depthwaterPressure = false; // owie not the billionare sub!!1
    public int currentDepthPressure = 0; // how deep = how many damage taje!!!1
    public override void ResetEffects()
    {
        SpaceVacuum = false;
        BlizzardFrozen = false;
        CrimtuptionzoneNight = false;
        Chilly = false;
        WaterEyes = false;
        StormEyeCovered = false;

        depthwaterPressure = false;
        currentDepthPressure = 0;
        
        WearingDivingHelm = false;
        WearingDivingGear = false;
        WearingJellyfishDivingGear = false;
        WearingArcticDivingGear = false;
        WearingAbyssalDivingGear = false;
        WearingAbyssalDivingSuit = false;

        WearingAnyArmour = false;
        WearingOneArmourPiece = false;
        WearingTwoArmourPieces = false;
        WearingFullArmour = false;

        WearingAnyEskimo = false;
        WearingOneEskimoPiece = false;
        WearingTwoEskimoPieces = false;
        WearingFullEskimo = false;

        WearingAnyAstralite = false;
        WearingOneAstralitePiece = false;
        WearingTwoAstralitePieces = false;
        WearingFullAstralite = false;
        WearingAstraliteVisor = false;

        WearingAnyAstro = false;
        WearingOneAstroPiece = false;
        WearingTwoAstroPieces = false;
        WearingFullAstro = false;
        WearingAstroHelm = false;

        IsWearingFishBowl = false;

        WearingAnyMetal = false;
        WearingOneMetalPiece = false;
        WearingTwoMetalPieces = false;
        WearingFullMetal = false;

        IrisSpiritPet = false;
    }
}
