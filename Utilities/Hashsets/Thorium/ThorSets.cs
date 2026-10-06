namespace LuneLib.Utilities.Hashsets.Thorium;

[JITWhenModsEnabled("ThoriumMod")]
public class ThorSets
{
    public static readonly HashSet<int> AquaticNPCs;

    public static readonly HashSet<int> AquaticBosses;

    public static readonly HashSet<int> IsAquaticTile;

    public static readonly HashSet<int> IsAquaticWall;

    public static readonly HashSet<int> ThoriumOreSet;

    static ThorSets()
    {

        bool isThorLoaded = ModLoader.HasMod("ThoriumMod");
        if (isThorLoaded)
        {
            AquaticNPCs = CreateThorNpcSpecificTypes();

            AquaticBosses = CreateThorBossSpecificTypes();

            IsAquaticTile = CreateThorTileSpecificTypes();

            IsAquaticWall = CreateThorWallSpecificTypes();

            ThoriumOreSet = CreateThoriumOreSet();
        }

    }

    private static HashSet<int> CreateThorNpcSpecificTypes() =>
    [

        #region Ocean npcs

            ModContent.NPCType<ZealousJellyfish>(),
            ModContent.NPCType<DistractingJellyfish>(),
            ModContent.NPCType<SpittingJellyfish>(),

        #endregion // should out to protohog for helping me for adding 4 names 

        #region aquatic depths

            #region prehardmode // should out to protohog for helping me for adding 4 names 

                ModContent.NPCType<ManofWar>(),
                ModContent.NPCType<Barracuda>(),
                ModContent.NPCType<Sharptooth>(),
                ModContent.NPCType<Blowfish>(),
                ModContent.NPCType<Hammerhead>(),
                ModContent.NPCType<GigaClam>(),
                ModContent.NPCType<Octopus>(),
                ModContent.NPCType<Globee>(),
                ModContent.NPCType<MorayBody>(),
                ModContent.NPCType<MorayHead>(),
                ModContent.NPCType<MorayTail>(),

            #endregion 

            #region hardmode

                ModContent.NPCType<FeedingFrenzy>(),
                ModContent.NPCType<FeedingFrenzy2>(),
                ModContent.NPCType<VampireSquid>(),
                ModContent.NPCType<CrownofThorns>(),
                ModContent.NPCType<Kraken>(),
                ModContent.NPCType<Blobfish>(),
                ModContent.NPCType<PutridSerpent>(),
                ModContent.NPCType<AbyssalAngler>(),
                ModContent.NPCType<AbyssalAngler2>(),
                ModContent.NPCType<VoltEelBody>(),
                ModContent.NPCType<VoltEelBody1>(),
                ModContent.NPCType<VoltEelBody2>(),
                ModContent.NPCType<VoltEelHead>(),
                ModContent.NPCType<VoltEelTail>(),
                ModContent.NPCType<Whale>(),
                ModContent.NPCType<SubmergedMimic>(),

                ModContent.NPCType<AquaticHallucination>(),
                ModContent.NPCType<AbyssalSpawn>(),

            #endregion

            #region critter

                ModContent.NPCType<DumboOctopus>(),
                ModContent.NPCType<DumboOctopusBase>(),
                ModContent.NPCType<PurpleDumboOctopus>(),
                ModContent.NPCType<GoldDumboOctopus>(),
                ModContent.NPCType<Lobster>(),
                ModContent.NPCType<BlueLobster>(),
                ModContent.NPCType<GoldLobster>(),
                ModContent.NPCType<GiantIsopod>(),

            #endregion

        #endregion

    ];

    private static HashSet<int> CreateThorBossSpecificTypes() =>
    [
        ModContent.NPCType<QueenJellyfish>(),
        ModContent.NPCType<ForgottenOne>(),
        ModContent.NPCType<ForgottenOneCracked>(),
        ModContent.NPCType<ForgottenOneReleased>(),
    ];

    private static HashSet<int> CreateThorTileSpecificTypes() =>
    [

        ModContent.TileType<GlowingMarineBlock>(),
        ModContent.TileType<LeakyMarineBlock>(),
        ModContent.TileType<LeakyMossyMarineBlock>(),
        ModContent.TileType<MossyMarineBlock>(),
        ModContent.TileType<RefinedMarineBlock>(),
        ModContent.TileType<BrackishClumpTile>(),
        ModContent.TileType<Aquamarine>(),
        ModContent.TileType<Aquaite>(),
        ModContent.TileType<DepthChestTile>(),
        ModContent.TileType<SynthGold>(),
        ModContent.TileType<SynthPlatinum>(),

        ModContent.TileType<DepthsAmethyst>(),
        ModContent.TileType<DepthsTopaz>(),
        ModContent.TileType<DepthsOpal>(),
        ModContent.TileType<DepthsAquamarine>(),
        ModContent.TileType<DepthsSapphire>(),
        ModContent.TileType<DepthsEmerald>(),
        ModContent.TileType<DepthsRuby>(),
        ModContent.TileType<DepthsDiamond>(),
        ModContent.TileType<DepthsAmber>(),
    ];

    private static HashSet<int> CreateThorWallSpecificTypes() =>
    [

        ModContent.WallType<MarineWall>(),
        ModContent.WallType<MarineWall2>(),
        ModContent.WallType<MarineWallDry>(),
        ModContent.WallType<RefinedMarineWall>(),
        ModContent.WallType<AquaiteScaleWall>(),

    ];

    private static HashSet<int> CreateThoriumOreSet() =>
    [
        // prehardmode
        ModContent.TileType<SynthGold>(),
        ModContent.TileType<SynthPlatinum>(),
        ModContent.TileType<SmoothCoal>(),
        ModContent.TileType<LifeQuartz>(),
        ModContent.TileType<ThoriumOre>(),
        ModContent.TileType<Aquaite>(),

        // hardmode
        ModContent.TileType<LodeStone>(),
        ModContent.TileType<ValadiumChunk>(),
        ModContent.TileType<IllumiteChunk>(),
    ];
}