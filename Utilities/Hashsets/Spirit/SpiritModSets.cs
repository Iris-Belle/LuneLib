namespace LuneLib.Utilities.Hashsets.Spirit;

[JITWhenModsEnabled("SpiritMod")]
public static class SpiritSets
{
    public static readonly HashSet<int> AbyssalProjectiles;

    public static readonly HashSet<int> AbyssalNPCs;

    public static readonly HashSet<int> AquaticBossProjectiles;

    static SpiritSets()
    {
        bool isSpiritLoaded = ModLoader.HasMod("SpiritMod");
        if (isSpiritLoaded)
        {

            AbyssalProjectiles = isSpiritLoaded ? CreateSpiritProjSpecificTypes() : [];

            AbyssalNPCs = isSpiritLoaded ? CreateSpiritNpcSpecificTypes() : [];

        }
    }

    private static HashSet<int> CreateSpiritProjSpecificTypes() =>
    [
        ModContent.ProjectileType<RyBolt>(),
        ModContent.ProjectileType<RyTentacle>(),
        ModContent.ProjectileType<TentacleSquid>(),
    ];

    private static HashSet<int> CreateSpiritNpcSpecificTypes() =>
    [
        ModContent.NPCType<Rylheian>(),
        ModContent.NPCType<SwollenFish>(),
        ModContent.NPCType<ElectricEel>(),
        ModContent.NPCType<Horned_Crustacean>(),
        ModContent.NPCType<ReaverShark>(),
        ModContent.NPCType<Swordfish>(),
        ModContent.NPCType<GildJelly>(),
        ModContent.NPCType<TinyCrab>(),
        ModContent.NPCType<RedSnapper>(),
        ModContent.NPCType<Floater1>(),
        ModContent.NPCType<Luvdisc>(),
        ModContent.NPCType<TubeWorm>(),
        ModContent.NPCType<Gulper>(),
        ModContent.NPCType<Crinoid>(),
        ModContent.NPCType<Grouper>(),
        ModContent.NPCType<Sea_Mandrake>(),
        ModContent.NPCType<PurpleClubberfish>(),
        ModContent.NPCType<Rockfish>(),
        ModContent.NPCType<SawtoothShark>(),
        ModContent.NPCType<Toxikarp>(),
        ModContent.NPCType<MangoJelly>(),
        ModContent.NPCType<Cavefish>(),
        ModContent.NPCType<AtlanticCod>(),
        ModContent.NPCType<CrismonTigerfish>(),
        ModContent.NPCType<GoldenCarp>(),
        ModContent.NPCType<Noxophyll>(),
        ModContent.NPCType<SpecularFish>(),
        ModContent.NPCType<NeonTetra>(),
        ModContent.NPCType<FrostMinnow>(),
        ModContent.NPCType<Ebonkoi>(),
        ModContent.NPCType<Prismite>(),
        ModContent.NPCType<Lardfish>(),
        ModContent.NPCType<Damselfish>(),
        ModContent.NPCType<WoodCrateMimic>(),
        ModContent.NPCType<IronCrateMimic>(),
        ModContent.NPCType<GoldCrateMimic>(),
    ];
}
