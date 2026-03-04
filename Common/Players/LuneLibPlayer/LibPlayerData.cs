namespace LuneLib.Common.Players.LuneLibPlayer;

public partial class LibPlayer : ModPlayer
{
    public bool SpaceVacuum = false; // In-space debuff
    public bool BlizzardFrozen = false; //Frozen Blizzard
    public bool Chilly = false; //in tundra
    public bool LeadPoison = false; // weaing lead armour
    public bool CrimtuptionzoneNight = false; // In crimtuption during night
    public bool depthwaterPressure = false; // owie not the billionare sub!!1
    public bool WaterEyes = false; // used for darker waters
    public bool StormEyeCovered = false; // i think this is for the blizzard and or the sandstorm
    public int currentDepthPressure = 0; // how deep = how many damage taje!!!1
    public bool IrisSpiritPet = false; // Custom pet
    public bool IsIris = false; // self explanatory

    public override void ResetEffects()
    {
        SpaceVacuum = false;
        BlizzardFrozen = false;
        LeadPoison = false;
        CrimtuptionzoneNight = false;
        Chilly = false;
        depthwaterPressure = false;
        WaterEyes = false;
        StormEyeCovered = false;

        currentDepthPressure = 0;

        IrisSpiritPet = false;
    }
}
