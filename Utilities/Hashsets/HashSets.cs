namespace LuneLib.Utilities.Hashsets;

public static class HashSets
{
    #region HashSet Contains Ore Tile

    public static bool HashSetContainsOreTile(int type) =>
        ContainsVanillaOreTile(type) || ContainsCalOreTile(type) ||
        ContainsSpiritOreTile(type) || ContainsThorOreTile(type);

    public static bool ContainsVanillaOreTile(int type) =>
        VanillaOreSets.VanillaOres.Contains(type);
    public static bool ContainsCalOreTile(int type) =>
        LuneLib.instance.CalamityModLoaded && CalOreSets.CalOreSet.Contains(type);
    public static bool ContainsSpiritOreTile(int type) =>
        LuneLib.instance.SpiritModLoaded && SpiritOreSets.SpiritOreSet.Contains(type);
    public static bool ContainsThorOreTile(int type) =>
        LuneLib.instance.ThoriumModLoaded && ThoriumOreSets.ThoriumOreSet.Contains(type);

    #endregion

    #region Metallic Armours

    public static bool IsMetalArmour(int type) => MetallicAmours(type);
    public static bool MetallicAmours(int type) => VanillaMetallicSets.MetallicArmourSets.Contains(type);

    #endregion

    #region HashSet Contains Abyss Proj

    public static bool HashSetContainsAbyssProj(int type) =>
        ContainsInfAbyssProj(type)
     || ContainsCalAbyssProj(type)
     || ContainsVanAbyssProj(type)
     || ContainsThorAbyssProj(type)
     || ContainsSpiritAbyssProj(type);

    public static bool ContainsInfAbyssProj(int type) =>
        LuneLib.instance.InfernumModeLoaded && InfSets.AbyssalProjectiles.Contains(type);
    public static bool ContainsCalAbyssProj(int type) =>
        LuneLib.instance.CalamityModLoaded && CalSets.AbyssalProjectiles.Contains(type);
    public static bool ContainsThorAbyssProj(int type) =>
        LuneLib.instance.ThoriumModLoaded && ThorSets.AbyssalProjectiles.Contains(type);
    public static bool ContainsSpiritAbyssProj(int type) =>
        LuneLib.instance.SpiritModLoaded && SpiritSets.AbyssalProjectiles.Contains(type);
    public static bool ContainsVanAbyssProj(int type) =>
        VanillaSets.AbyssalProjectiles.Contains(type);

    #endregion

    #region HashSet Contains Abyssal Predator

    public static bool HashSetContainsAbyssalPredator(int type) =>
        ContainsCalAbyssalPredator(type)
     || ContainsInfAbyssalPredator(type)
     || ContainsCalExAbyssalPredator(type)
     || ContainsVanAbyssalPredator(type)
     || ContainsThorAbyssalPredator(type)
     || ContainsSpiritAbyssalPredator(type);

    public static bool ContainsCalAbyssalPredator(int type) =>
        LuneLib.instance.CalamityModLoaded && CalSets.AbyssalNPCs.Contains(type);
    public static bool ContainsInfAbyssalPredator(int type) =>
        LuneLib.instance.InfernumModeLoaded && InfSets.AbyssalNPCs.Contains(type);
    public static bool ContainsCalExAbyssalPredator(int type) =>
        LuneLib.instance.CalValExLoaded && CalEXSets.AbyssalNPCs.Contains(type);
    public static bool ContainsThorAbyssalPredator(int type) =>
        LuneLib.instance.ThoriumModLoaded && ThorSets.AbyssalNPCs.Contains(type);
    public static bool ContainsSpiritAbyssalPredator(int type) =>
        LuneLib.instance.SpiritModLoaded && SpiritSets.AbyssalNPCs.Contains(type);
    public static bool ContainsVanAbyssalPredator(int type) =>
        VanillaSets.AbyssalNPCs.Contains(type);

    #endregion

    #region HashSet Contains Aquatic Boss Projectile

    public static bool HashSetContainsAquaticBossProjectile(int type) =>
        ContainsCalAquaticBossProjectile(type) || ContainsInfAquaticBossProjectile(type) || ContainsThorAquaticBossProjectile(type);

    public static bool ContainsCalAquaticBossProjectile(int type) =>
        LuneLib.instance.CalamityModLoaded && CalSets.AquaticBossProjectiles.Contains(type);
    public static bool ContainsInfAquaticBossProjectile(int type) =>
        LuneLib.instance.InfernumModeLoaded && InfSets.AquaticBossProjectiles.Contains(type);
    public static bool ContainsThorAquaticBossProjectile(int type) =>
        LuneLib.instance.ThoriumModLoaded && ThorSets.AquaticBossProjectiles.Contains(type);

    #endregion

    #region HashSet Contains Aquatic Boss

    public static bool HashSetContainsAquaticBoss(int type) =>
        ContainsCalAquaticBoss(type) || ContainsInfAquaticBossProjectile(type) || ContainsVanAquaticBoss(type) || ContainsThorAquaticBoss(type);

    public static bool ContainsCalAquaticBoss(int type) =>
        LuneLib.instance.CalamityModLoaded && CalSets.AquaticBosses.Contains(type);
    public static bool ContainsThorAquaticBoss(int type) =>
        LuneLib.instance.ThoriumModLoaded && ThorSets.AquaticBosses.Contains(type);
    public static bool ContainsVanAquaticBoss(int type) =>
        VanillaSets.AquaticBosses.Contains(type);

    #endregion

    #region HashSet Contains Aquatic Tile

    public static bool HashSetContainsAquaticTile(int type) =>
        ContainsCalAquaticTile(type) || ContainsThorAquaticTile(type);

    public static bool ContainsCalAquaticTile(int type) =>
        LuneLib.instance.CalamityModLoaded && CalSets.IsAquaticTile.Contains(type);

    public static bool ContainsThorAquaticTile(int type) =>
        LuneLib.instance.ThoriumModLoaded && ThorSets.IsAquaticTile.Contains(type);

    #endregion

    #region HashSet Contains Aquatic Wall

    public static bool HashSetContainsCalAquaticWall(int type) =>
        ContainsCalAquaticWall(type) || ContainsThorAquaticWall(type);

    public static bool ContainsCalAquaticWall(int type) =>
        LuneLib.instance.CalamityModLoaded && CalSets.IsAquaticWall.Contains(type);
    public static bool ContainsThorAquaticWall(int type) =>
        LuneLib.instance.ThoriumModLoaded && ThorSets.IsAquaticWall.Contains(type);

    #endregion
}