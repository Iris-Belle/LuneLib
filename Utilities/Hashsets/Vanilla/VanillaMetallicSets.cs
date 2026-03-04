namespace LuneLib.Utilities.Hashsets.Vanilla;

public static class VanillaMetallicSets
{
    public static readonly HashSet<int> MetallicArmourSets;
    static VanillaMetallicSets() => MetallicArmour();
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
