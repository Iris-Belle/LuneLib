namespace LuneLib.Utilities.Hashsets.Calamity;

[JITWhenModsEnabled("InfernumMode")]
public static class InfSets
{

    public static readonly HashSet<int> AquaticNPCs;

    static InfSets()
    {
        bool isInfCalLoaded = ModLoader.HasMod("InfernumMode");
        if (isInfCalLoaded)
            AquaticNPCs = CreateInfCalNpcSpecificTypes();
    }

    private static HashSet<int> CreateInfCalNpcSpecificTypes() =>
    [
            ModContent.NPCType<DepthFeeder>(),
            ModContent.NPCType<Herring>(),
            ModContent.NPCType<LionfishEnemy>(),
            ModContent.NPCType<RedirectingBubble>(),
    ];
}