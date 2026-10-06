namespace LuneLib.Common.Players.LuneLibPlayer;

public partial class LibPlayer : ModPlayer
{
    #region future me, these flags are for DOT checks
    public bool SpaceVacuum = false; // In-space debuff
    public bool InEvilBiomeAtNight = false; // In crimtuption during night

    public bool TundraGivesChilled = false; //in tundra
    public bool BlizzardGivesFrozen = false; //Frozen Blizzard 

    public bool DepthWaterPressure = false; // owie not the billionare sub!!1
    #endregion

    public bool MurkyWaterFlag = false;
    public bool ReducedVisionInStorms = false; // sandstorm
    public int CurrentDepthPressure = 0; // how deep = how many damage taje!!!1
    public bool IrisSpiritPet = false; // Custom pet
    public override void ResetEffects()
    {
        SpaceVacuum = false;
        InEvilBiomeAtNight = false;

        TundraGivesChilled = false;
        BlizzardGivesFrozen = false; 

        MurkyWaterFlag = false;
        ReducedVisionInStorms = false;

        DepthWaterPressure = false;
        CurrentDepthPressure = 0;

        IrisSpiritPet = false;

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
    }
}
