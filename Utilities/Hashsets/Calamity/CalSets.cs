namespace LuneLib.Utilities.Hashsets.Calamity;

[JITWhenModsEnabled("CalamityMod")]
public static class CalSets
{

    public static readonly HashSet<int> AbyssalProjectiles;

    public static readonly HashSet<int> AbyssalNPCs;

    public static readonly HashSet<int> AquaticBossProjectiles;

    public static readonly HashSet<int> AquaticBosses;

    public static readonly HashSet<int> IsAquaticTile;

    public static readonly HashSet<int> IsAquaticWall;

    static CalSets()
    {

        bool isCalLoaded = ModLoader.HasMod("CalamityMod");

        AbyssalProjectiles = isCalLoaded ? CreateCalProjSpecificTypes() : [];

        AbyssalNPCs = isCalLoaded ? CreateCalNpcSpecificTypes() : [];

        AquaticBossProjectiles = isCalLoaded ? CreateCalBossProjSpecificTypes() : [];

        AquaticBosses = isCalLoaded ? CreateCalBossSpecificTypes() : [];

        IsAquaticTile = isCalLoaded ? CreateCalTileSpecificTypes() : [];

        IsAquaticWall = isCalLoaded ? CreateCalWallSpecificTypes() : [];

    }

    #region Abyssal Projectiles

    private static HashSet<int> CreateCalProjSpecificTypes() =>
    [

        #region Calamity Mod Projectiles

            #region Sulphurous Sea

                ModContent.ProjectileType<SulphuricAcidMist>(),
                ModContent.ProjectileType<SulphuricAcidBubble>(),
                ModContent.ProjectileType<AcidDrop>(),
                ModContent.ProjectileType<BelchingCoralSpike>(),
                ModContent.ProjectileType<FlakAcid>(),
                ModContent.ProjectileType<GammaAcid>(),
                ModContent.ProjectileType<GammaBeam>(),
                ModContent.ProjectileType<NuclearToadGoo>(),
                ModContent.ProjectileType<OrthoceraStream>(),
                ModContent.ProjectileType<CrabBoulder>(),
                ModContent.ProjectileType<TrilobiteSpike>(),

            #endregion

            #region Sunken Sea

                ModContent.ProjectileType<HorsWaterBlast>(),

            #endregion

            #region Abyss

                ModContent.ProjectileType<LavaChunk>(),
                ModContent.ProjectileType<MurkySteam>(),
                ModContent.ProjectileType<ThermalSteam>(),
                ModContent.ProjectileType<HotSteam>(),

                #region Abyss Layer1

                    ModContent.ProjectileType<ToxicMinnowCloud>(),

                #endregion

                #region Abyss Layer2

                #endregion

                #region Abyss Layer3

                    ModContent.ProjectileType<PufferExplosion>(),

                #endregion

                #region Abyss Layer4

                #endregion

            #endregion

        #endregion

    ];

    #endregion

    #region Abyssal Npcs

    private static HashSet<int> CreateCalNpcSpecificTypes() =>
    [
        ModContent.NPCType<FearlessGoldfishWarrior>(),

            #region Ocean

                ModContent.NPCType<Frogfish>(),
                ModContent.NPCType<AquaticUrchin>(),
                ModContent.NPCType<MantisShrimp>(),
                ModContent.NPCType<AquaticAberration>(),

            #endregion

            #region Sulphurous Sea NPCs

                ModContent.NPCType<Gnasher>(),
                ModContent.NPCType<Trasher>(),
                ModContent.NPCType<AnthozoanCrab>(),
                ModContent.NPCType<BabyFlakCrab>(),
                ModContent.NPCType<BelchingCoral>(),
                ModContent.NPCType<AquaticScourgeHead>(),
                ModContent.NPCType<AquaticScourgeBody>(),
                ModContent.NPCType<AquaticScourgeBodyAlt>(),
                ModContent.NPCType<AquaticScourgeTail>(),
                ModContent.NPCType<OldDuke>(),
                ModContent.NPCType<SulphurousSharkron>(),

            //acid rain specific
                ModContent.NPCType<AcidEel>(),
                ModContent.NPCType<NuclearToad>(),
                ModContent.NPCType<Radiator>(),
                ModContent.NPCType<Skyfin>(),

                ModContent.NPCType<FlakCrab>(),
                ModContent.NPCType<IrradiatedSlime>(),
                ModContent.NPCType<Orthocera>(),
                ModContent.NPCType<SulphurousSkater>(),
                ModContent.NPCType<Trilobite>(),
                ModContent.NPCType<GammaSlime>(),
                ModContent.NPCType<Mauler>(),
                ModContent.NPCType<NuclearTerror>(),

            #endregion

            #region Sunken Sea

                ModContent.NPCType<Clam>(),
                ModContent.NPCType<EutrophicRay>(),
                ModContent.NPCType<GhostBell>(),
                ModContent.NPCType<PrismBack>(),
                ModContent.NPCType<SeaFloaty>(),
                ModContent.NPCType<GiantClam>(),
                ModContent.NPCType<BlindedAngler>(),
                ModContent.NPCType<SeaSerpent1>(),
                ModContent.NPCType<SeaSerpent2>(),
                ModContent.NPCType<SeaSerpent3>(),
                ModContent.NPCType<SeaSerpent4>(),
                ModContent.NPCType<SeaSerpent5>(),
                ModContent.NPCType<BabyGhostBell>(),
                ModContent.NPCType<SeaMinnow>(),

            #endregion

            #region Layer1

                ModContent.NPCType<AquaticUrchin>(),
                ModContent.NPCType<BabyCannonballJellyfish>(),
                ModContent.NPCType<BoxJellyfish>(),
                ModContent.NPCType<CannonballJellyfish>(),
                ModContent.NPCType<MorayEel>(),
                ModContent.NPCType<SlabCrab>(),
                ModContent.NPCType<Sulflounder>(),
                ModContent.NPCType<Toxicatfish>(),
                ModContent.NPCType<ToxicMinnow>(),

            #endregion

            #region Layer2

                ModContent.NPCType<Cuttlefish>(),
                ModContent.NPCType<LuminousCorvina>(),
                ModContent.NPCType<Laserfish>(),
                ModContent.NPCType<OarfishHead>(),
                ModContent.NPCType<OarfishBody>(),
                ModContent.NPCType<OarfishTail>(),
                ModContent.NPCType<Viperfish>(),

            #endregion

            #region Layer3

                ModContent.NPCType<ChaoticPuffer>(),
                ModContent.NPCType<DevilFish>(),
                ModContent.NPCType<DevilFishAlt>(),
                ModContent.NPCType<GiantSquid>(),
                ModContent.NPCType<MirageJelly>(),
                ModContent.NPCType<ColossalSquid>(),
                ModContent.NPCType<Eidolist>(),
                ModContent.NPCType<GulperEelHead>(),
                ModContent.NPCType<GulperEelBody>(),
                ModContent.NPCType<GulperEelBodyAlt>(),
                ModContent.NPCType<GulperEelTail>(),

            #endregion

            #region Layer4

                ModContent.NPCType<Bloatfish>(),
                ModContent.NPCType<BobbitWormHead>(),
                ModContent.NPCType<BobbitWormSegment>(),
                ModContent.NPCType<EidolonWyrmHead>(),
                ModContent.NPCType<EidolonWyrmBody>(),
                ModContent.NPCType<EidolonWyrmBodyAlt>(),
                ModContent.NPCType<EidolonWyrmTail>(),
                ModContent.NPCType<ReaperShark>(),
                ModContent.NPCType<PrimordialWyrmHead>(),
                ModContent.NPCType<PrimordialWyrmBody>(),
                ModContent.NPCType<PrimordialWyrmBodyAlt>(),
                ModContent.NPCType<PrimordialWyrmTail>(),

            #endregion

    ];

    #endregion

    #region Aquatic Boss Projectiles

    private static HashSet<int> CreateCalBossProjSpecificTypes() =>
    [

        #region Anahita

            ModContent.ProjectileType<WaterSpear>(),
            ModContent.ProjectileType<FrostMist>(),

        #endregion

        #region Leviathan

            ModContent.ProjectileType<LeviathanBomb>(),

        #endregion

        #region Old Duke

            ModContent.ProjectileType<OldDukeToothBallSpike>(),
            ModContent.ProjectileType<OldDukeVortex>(),
            ModContent.ProjectileType<SandPoisonCloudOldDuke>(),
            ModContent.ProjectileType<OverlyDramaticDukeSummoner>(),

        #endregion

        #region Aquatic Scourge

            ModContent.ProjectileType<ToxicCloud>(),
            ModContent.ProjectileType<SandTooth>(),
            ModContent.ProjectileType<SandPoisonCloud>(),

        #endregion

        #region Acid Rain

            #region CragmawMire

                ModContent.ProjectileType<CragmawSpike>(),
                ModContent.ProjectileType<CragmawExplosion>(),
                ModContent.ProjectileType<CragmawAcidDrop>(),
                ModContent.ProjectileType<CragmawBeam>(),
                ModContent.ProjectileType<CragmawVibeCheckChain>(),

            #endregion

            #region Mauler

                ModContent.ProjectileType<MaulerAcidBubble>(),
                ModContent.ProjectileType<MaulerAcidDrop>(),

            #endregion

            #region Nuclear Terror

                ModContent.ProjectileType<GammaRayBurst>(),
                ModContent.ProjectileType<NuclearBulletMedium>(),
                ModContent.ProjectileType<NuclearBulletLarge>(),

            #endregion

        #endregion

        #region Giant Clam

            ModContent.ProjectileType<PearlBurst>(),
            ModContent.ProjectileType<PearlRain>(),

        #endregion

        #region Colossal Squidward

            ModContent.ProjectileType<InkBombHostile>(),
            ModContent.ProjectileType<InkPoisonCloud>(),

        #endregion

        #region Primordial Wyrm (Adult Eidolon Wyrm)

        #endregion

        #region Reaper? aw man... so we back in the mine

        #endregion

    ];

    #endregion

    #region Aquatic Bosses

    private static HashSet<int> CreateCalBossSpecificTypes() =>
    [

        #region Ocean

            #region Anahita

                ModContent.NPCType<Anahita>(),
                ModContent.NPCType<LeviathanStart>(),

                ModContent.NPCType<Leviathan>(),

            #endregion

        #endregion

        #region Sulphurous Sea NPCs

            #region Old Duke

                ModContent.NPCType<OldDuke>(),
                ModContent.NPCType<OldDukeToothBall>(),
                ModContent.NPCType<SulphurousSharkron>(),

            #endregion

            #region Aquatic Scourge

                ModContent.NPCType<AquaticScourgeHead>(),
                ModContent.NPCType<AquaticScourgeBody>(),
                ModContent.NPCType<AquaticScourgeBodyAlt>(),
                ModContent.NPCType<AquaticScourgeTail>(),

            #endregion

            #region Acid Rain

                ModContent.NPCType<CragmawMire>(),
                ModContent.NPCType<Mauler>(),
                ModContent.NPCType<NuclearTerror>(),

            #endregion

        #endregion

        #region Sunken Sea

            ModContent.NPCType<GiantClam>(),

        #endregion

        #region Layer3

            ModContent.NPCType<ColossalSquid>(),

        #endregion

        #region Layer4

            ModContent.NPCType<EidolonWyrmHead>(),
            ModContent.NPCType<EidolonWyrmBody>(),
            ModContent.NPCType<EidolonWyrmBodyAlt>(),
            ModContent.NPCType<EidolonWyrmTail>(),
            ModContent.NPCType<ReaperShark>(),
            ModContent.NPCType<PrimordialWyrmHead>(),
            ModContent.NPCType<PrimordialWyrmBody>(),
            ModContent.NPCType<PrimordialWyrmBodyAlt>(),
            ModContent.NPCType<PrimordialWyrmTail>(),

        #endregion

    ];

    #endregion

    #region Is Aquatic Tile

    private static HashSet<int> CreateCalTileSpecificTypes() =>
    [

            ModContent.TileType<SulphurousSand>(),
            ModContent.TileType<HardenedSulphurousSandstone>(),
            ModContent.TileType<SulphurousSandstone>(),
            ModContent.TileType<EutrophicSand>(),
            ModContent.TileType<Navystone>(),
            ModContent.TileType<SeaPrism>(),
            ModContent.TileType<SeaPrismCrystals>(),
            ModContent.TileType<SulphurousShale>(),
            ModContent.TileType<AbyssGravel>(),
            ModContent.TileType<PyreMantle>(),
            ModContent.TileType<PyreMantleMolten>(),
            ModContent.TileType<Voidstone>(),
            ModContent.TileType<ScoriaOre>(),
            ModContent.TileType<PlantyMush>(),
            ModContent.TileType<MassiveRarePearl>(),

    ];

    #endregion

    #region Is Aquatic Wall

    private static HashSet<int> CreateCalWallSpecificTypes() =>
    [

        ModContent.WallType<EutrophicSandWall>(),
        ModContent.WallType<EutrophicSandWallSafe>(),
        ModContent.WallType<NavystoneWall>(),
        ModContent.WallType<UnsafeNavystoneWall>(),
        ModContent.WallType<SulphurousSandWall>(),
        ModContent.WallType<UnsafeSulphurousSandWall>(),
        ModContent.WallType<UnsafeAbyssGravelWall>(),
        ModContent.WallType<SafeAbyssGravelWall>(),
        ModContent.WallType<SmoothAbyssGravelWall>(),
        ModContent.WallType<PyreMantleWall>(),
        ModContent.WallType<VoidstoneWall>(),
        ModContent.WallType<UnsafeVoidstoneWall>(),
        ModContent.WallType<VoidstoneSlabWall>(),
        ModContent.WallType<SmoothVoidstoneWall>(),

    ];

    #endregion
}