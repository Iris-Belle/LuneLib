namespace LuneLib.Utilities.Hashsets.Spirit;

[JITWhenModsEnabled("SpiritMod")]
public static class SpiritSets
{
    public static readonly HashSet<int> AquaticNPCs;

    public static readonly HashSet<int> SpiritOreSet;

    static SpiritSets()
    {
        bool isSpiritLoaded = ModLoader.HasMod("SpiritMod");
        if (isSpiritLoaded)
        {
            AquaticNPCs = CreateSpiritNpcSpecificTypes();
            SpiritOreSet = CreateSpiritOreSet();
        }
    }

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

    private static HashSet<int> CreateSpiritOreSet() =>
    [
        // prehardmode
        ModContent.TileType<BismiteCrystalOre>(),
        ModContent.TileType<FloranOreTile>(),
        ModContent.TileType<MarbleOre>(),
        ModContent.TileType<GraniteOre>(),
        ModContent.TileType<Glowstone>(),
        ModContent.TileType<CryoliteOreTile>(),

        // hardmode
        ModContent.TileType<SpiritOreTile>(),
    ];
}
