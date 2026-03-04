namespace LuneLib.Utilities.Hashsets.Calamity;

[JITWhenModsEnabled("InfernumMode")]
public static class InfSets
{
    public static readonly HashSet<int> AbyssalProjectiles;

    public static readonly HashSet<int> AbyssalNPCs;

    public static readonly HashSet<int> AquaticBossProjectiles;

    static InfSets()
    {
        bool isInfCalLoaded = ModLoader.HasMod("InfernumMode");
        if (isInfCalLoaded)
        {

            AbyssalProjectiles = isInfCalLoaded ? CreateInfCalProjSpecificTypes() : [];

            AbyssalNPCs = isInfCalLoaded ? CreateInfCalNpcSpecificTypes() : [];

            AquaticBossProjectiles = isInfCalLoaded ? CreateInfCalBossProjSpecificTypes() : [];

        }
    }

    private static HashSet<int> CreateInfCalProjSpecificTypes() =>
    [
            #region Abyss

                #region Abyss Layer1

                    ModContent.ProjectileType<BoxJellyZap>(),

                #endregion

                #region Abyss Layer3

                    ModContent.ProjectileType<DevilfishExplosion>(),

                #endregion

                #region Abyss Layer4

                    ModContent.ProjectileType<EidolistElectricOrb>(),
                    ModContent.ProjectileType<EidolistElectricOrb2>(),
                    ModContent.ProjectileType<EidolistIceBomb>(),
                    ModContent.ProjectileType<EidolistLightning>(),
                    ModContent.ProjectileType<EidolistRitual>(),
                    ModContent.ProjectileType<ElectricPulse>(),
                    ModContent.ProjectileType<EidolistIce>(),

                #endregion

            #endregion
    ];

    private static HashSet<int> CreateInfCalNpcSpecificTypes() =>
    [
            ModContent.NPCType<DepthFeeder>(),
            ModContent.NPCType<Herring>(),
            ModContent.NPCType<LionfishEnemy>(),
            ModContent.NPCType<ColossalSquidTentacle>(),
            ModContent.NPCType<RedirectingBubble>(),
    ];

    private static HashSet<int> CreateInfCalBossProjSpecificTypes() =>
    [

        #region Anahita

            ModContent.ProjectileType<AnahitaWaterIllusion>(),
            ModContent.ProjectileType<HeavenlyLullaby>(),
            ModContent.ProjectileType<WaterBolt>(),
            ModContent.ProjectileType<RedirectingWaterBolt>(),
            ModContent.ProjectileType<AtlantisSpear>(),
            ModContent.ProjectileType<AtlantisSpear2>(),

        #endregion

        #region Leviathan

            ModContent.ProjectileType<LeviathanVomit>(),
            ModContent.ProjectileType<LeviathanMeteor>(),
            ModContent.ProjectileType<AquaticAberrationProj>(),

        #endregion

        #region Old Duke

            ModContent.ProjectileType<OldDukeTooth>(),
            ModContent.ProjectileType<HomingAcid>(),
            ModContent.ProjectileType<OldDukeTooth>(),
            ModContent.ProjectileType<SharkSummonVortex>(),
            ModContent.ProjectileType<SulphuricBlob>(),

        #endregion

        #region Aquatic Scourge

            ModContent.ProjectileType<AcidBubble>(),
            ModContent.ProjectileType<WaterClearingBubble>(),
            ModContent.ProjectileType<AquaticScourgeBodySpike>(),
            ModContent.ProjectileType<LeechFeeder>(),
            ModContent.ProjectileType<SulphuricGas>(),
            ModContent.ProjectileType<AcceleratingArcingAcid>(),
            ModContent.ProjectileType<RadiationPulse>(),
            ModContent.ProjectileType<SulphuricGasDebuff>(),
            ModContent.ProjectileType<SulphurousRockRubble>(),
            ModContent.ProjectileType<SulphuricTornado>(),
            ModContent.ProjectileType<FallingAcid>(),

        #endregion

        #region Acid Rain

            ModContent.ProjectileType<GammaRain>(),
            ModContent.ProjectileType<GammaBurstLineTelegraph>(),
            ModContent.ProjectileType<ConvergingGammaEnergy>(),
            ModContent.ProjectileType<GammaSuperDeathray>(),

        #endregion

        #region Giant Clam

            ModContent.ProjectileType<PearlSwirl>(),

        #endregion

        #region Colossal Squidward

            ModContent.ProjectileType<InkBlob>(),
            ModContent.ProjectileType<InkBolt>(),

        #endregion

        #region Primordial Wyrm (Adult Eidolon Wyrm)

            ModContent.ProjectileType<TerminusAnimationProj>(),
            ModContent.ProjectileType<AEWTelegraphLine>(),
            ModContent.ProjectileType<DivineLightBolt>(),
            ModContent.ProjectileType<DivineLightOrb>(),
            ModContent.ProjectileType<DivineLightLaserbeam>(),
            ModContent.ProjectileType<TerminusDeathray>(),
            ModContent.ProjectileType<HorizontalRayTerminus>(),
            ModContent.ProjectileType<AEWNightmareWyrm>(),
            ModContent.ProjectileType<AbyssalSoul>(),
            ModContent.ProjectileType<AbyssalSoulTelegraph>(),
            ModContent.ProjectileType<AEWIllusionTelegraphLine>(),
            ModContent.ProjectileType<ConvergingLumenylCrystal>(),
            ModContent.ProjectileType<AEWSplitForm>(),
            ModContent.ProjectileType<CircleCenterTelegraph>(),
            ModContent.ProjectileType<PsychicBlast>(),
            ModContent.ProjectileType<SimpleAbyssalSoul>(),
            ModContent.ProjectileType<BaseAttackingTerminusProjectile>(),

        #endregion

        #region Reaper? aw man... so we back in the mine

            ModContent.ProjectileType<MiniReaperShark>(),
            ModContent.ProjectileType<ReaperSharkIceBreath>(),
            ModContent.ProjectileType<AbyssalIce>(),

        #endregion

    ];
}