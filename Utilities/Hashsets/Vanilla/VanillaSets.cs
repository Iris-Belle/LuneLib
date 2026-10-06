namespace LuneLib.Utilities.Hashsets.Vanilla;

public static class VanillaSets
{

    public static readonly HashSet<int> AquaticNPCs;

    public static readonly HashSet<int> AquaticBosses;

    public static readonly HashSet<int> VanillaOres;

    public static readonly HashSet<int> MetallicArmourSets;

    static VanillaSets()
    {
        AquaticNPCs = CreateVanillaNpcSpecificTypes();

        AquaticBosses = CreateVanillaBossSpecificTypes();

        VanillaOres = CreateVanillaOresSet();

        MetallicArmourSets = MetallicArmour();
    }

    private static HashSet<int> CreateVanillaNpcSpecificTypes() =>
    [
            NPCID.BlueJellyfish,
            NPCID.BloodJelly,
            NPCID.Crab,
            NPCID.DetonatingBubble,
            NPCID.Dolphin,
            NPCID.DukeFishron,
            NPCID.GoldSeahorse,
            NPCID.GreenJellyfish,
            NPCID.PinkJellyfish,
            NPCID.SeaSnail,
            NPCID.SeaTurtle,
            NPCID.Seahorse,
            NPCID.Shark,
            NPCID.Sharkron,
            NPCID.Squid,
            NPCID.AnglerFish,
            NPCID.Arapaima,
            NPCID.BloodFeeder,
            NPCID.CorruptGoldfish,
            NPCID.FlyingFish,
            NPCID.FungoFish,
            NPCID.Piranha,
            NPCID.SeaSnail,
            NPCID.Sharkron,
            NPCID.Sharkron2,
            NPCID.Squid,
            NPCID.CrimsonGoldfish,
            NPCID.Goldfish,
            NPCID.GoldfishWalker,
    ];

    private static HashSet<int> CreateVanillaBossSpecificTypes() =>
    [
            NPCID.DukeFishron,
    ];

    private static HashSet<int> CreateVanillaOresSet() =>
    [
        #region prehardmode
        TileID.Silt,
        TileID.Slush,
        TileID.DesertFossil,

        TileID.Copper,
        TileID.Iron,
        TileID.Silver,
        TileID.Gold,

        TileID.Tin,
        TileID.Lead,
        TileID.Tungsten,
        TileID.Platinum,

        TileID.Meteorite,

        TileID.Demonite,
        TileID.Crimtane,

        TileID.Obsidian,
        TileID.Hellstone,
        #endregion

        #region hardmode
        TileID.Cobalt,
        TileID.Mythril,
        TileID.Titanium,

        TileID.Palladium,
        TileID.Orichalcum,
        TileID.Adamantite,

        TileID.Chlorophyte,
        TileID.LunarOre,
        #endregion
    ];

    private static HashSet<int> MetallicArmour() =>
    [
        #region Prehardmode
        ItemID.CopperHelmet,
        ItemID.CopperChainmail,
        ItemID.CopperGreaves,

        ItemID.TinHelmet,
        ItemID.TinChainmail,
        ItemID.TinGreaves,

        ItemID.IronHelmet,
        ItemID.IronChainmail,
        ItemID.IronGreaves,

        ItemID.LeadHelmet,
        ItemID.LeadChainmail,
        ItemID.LeadGreaves,

        ItemID.SilverHelmet,
        ItemID.SilverChainmail,
        ItemID.SilverGreaves,

        ItemID.TungstenHelmet,
        ItemID.TungstenChainmail,
        ItemID.TungstenGreaves,

        ItemID.GoldHelmet,
        ItemID.GoldChainmail,
        ItemID.GoldGreaves,

        ItemID.PlatinumHelmet,
        ItemID.PlatinumChainmail,
        ItemID.PlatinumGreaves,

        ItemID.GladiatorHelmet,
        ItemID.GladiatorBreastplate,
        ItemID.GladiatorLeggings,

        ItemID.MeteorHelmet,
        ItemID.MeteorSuit,
        ItemID.MeteorLeggings,

        ItemID.AncientCobaltHelmet,
        ItemID.AncientCobaltBreastplate,
        ItemID.AncientCobaltLeggings,

        ItemID.ShadowHelmet,
        ItemID.ShadowScalemail,
        ItemID.ShadowGreaves,

        ItemID.AncientShadowHelmet,
        ItemID.AncientShadowScalemail,
        ItemID.AncientShadowGreaves,

        ItemID.CrimsonHelmet,
        ItemID.CrimsonScalemail,
        ItemID.CrimsonGreaves,

        ItemID.MoltenHelmet,
        ItemID.MoltenBreastplate,
        ItemID.MoltenGreaves,
        #endregion

        #region  hardmode
        ItemID.CobaltHat,
        ItemID.CobaltHelmet,
        ItemID.CobaltMask,
        ItemID.CobaltBreastplate,
        ItemID.CobaltLeggings,

        ItemID.PalladiumHelmet,
        ItemID.PalladiumHeadgear,
        ItemID.PalladiumMask,
        ItemID.PalladiumBreastplate,
        ItemID.PalladiumLeggings,

        ItemID.MythrilHat,
        ItemID.MythrilHelmet,
        ItemID.MythrilHood,
        ItemID.MythrilChainmail,
        ItemID.MythrilGreaves,

        ItemID.OrichalcumHeadgear,
        ItemID.OrichalcumHelmet,
        ItemID.OrichalcumMask,
        ItemID.OrichalcumBreastplate,
        ItemID.OrichalcumLeggings,

        ItemID.AdamantiteHeadgear,
        ItemID.AdamantiteHelmet,
        ItemID.AdamantiteMask,
        ItemID.AdamantiteBreastplate,
        ItemID.AdamantiteLeggings,

        ItemID.TitaniumHeadgear,
        ItemID.TitaniumHelmet,
        ItemID.TitaniumMask,
        ItemID.TitaniumBreastplate,
        ItemID.TitaniumLeggings,

        ItemID.FrostHelmet,
        ItemID.FrostBreastplate,
        ItemID.FrostLeggings,

        ItemID.AncientBattleArmorHat,
        ItemID.AncientBattleArmorShirt,
        ItemID.AncientBattleArmorPants,

        ItemID.HallowedHeadgear,
        ItemID.HallowedHelmet,
        ItemID.HallowedHood,
        ItemID.HallowedMask,
        ItemID.HallowedPlateMail,
        ItemID.HallowedGreaves,

        ItemID.AncientHallowedHeadgear,
        ItemID.AncientHallowedHelmet,
        ItemID.AncientHallowedHood,
        ItemID.AncientHallowedMask,
        ItemID.AncientHallowedPlateMail,
        ItemID.AncientHallowedGreaves,

        ItemID.EmptyBucket,
        #endregion
    ];
}