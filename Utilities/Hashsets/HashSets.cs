namespace LuneLib.Utilities.Hashsets;

public static class HashSets
{

    #region HashSet Contains Ore Tile

    public static bool HashSetContainsOreTile(int type) => ContainsVanillaOreTile(type) || ContainsCalOreTile(type) || ContainsSpiritOreTile(type) || ContainsThorOreTile(type);

    public static bool ContainsVanillaOreTile(int type) => VanillaSets.VanillaOres.Contains(type);
    public static bool ContainsCalOreTile(int type) => instance.CalamityModLoaded && CalSets.CalOreSet.Contains(type);
    public static bool ContainsSpiritOreTile(int type) => instance.SpiritModLoaded && SpiritSets.SpiritOreSet.Contains(type);
    public static bool ContainsThorOreTile(int type) => instance.ThoriumModLoaded && ThorSets.ThoriumOreSet.Contains(type);

    #endregion

    #region Metallic Armours

    public static bool IsMetalArmour(int type) => MetallicAmours(type);
    public static bool MetallicAmours(int type) => VanillaSets.MetallicArmourSets.Contains(type);

    #endregion

    #region HashSet Contains Abyss Proj

    public static bool HashSetContainsAbyssProj(int type) => ContainsCalAbyssProj(type);

    public static bool ContainsCalAbyssProj(int type) => instance.CalamityModLoaded && CalSets.AquaticProjectiles.Contains(type);

    #endregion

    #region HashSet Contains Aquatic Predator

    public static bool HashSetContainsAquaticPredator(int type) => ContainsCalAquaticPredator(type) || ContainsInfAquaticPredator(type) || ContainsCalExAquaticPredator(type) || ContainsVanAquaticPredator(type) || ContainsThorAquaticPredator(type) || ContainsSpiritAquaticPredator(type);

    public static bool ContainsCalAquaticPredator(int type) => instance.CalamityModLoaded && CalSets.AquaticNPCs.Contains(type);
    public static bool ContainsInfAquaticPredator(int type) => instance.InfernumModeLoaded && InfSets.AquaticNPCs.Contains(type);
    public static bool ContainsCalExAquaticPredator(int type) => instance.CalValExLoaded && CalEXSets.AquaticNPCs.Contains(type);
    public static bool ContainsThorAquaticPredator(int type) => instance.ThoriumModLoaded && ThorSets.AquaticNPCs.Contains(type);
    public static bool ContainsSpiritAquaticPredator(int type) => instance.SpiritModLoaded && SpiritSets.AquaticNPCs.Contains(type);
    public static bool ContainsVanAquaticPredator(int type) => VanillaSets.AquaticNPCs.Contains(type);

    #endregion

    #region HashSet Contains Aquatic Boss

    public static bool HashSetContainsAquaticBoss(int type) => ContainsCalAquaticBoss(type) || ContainsVanAquaticBoss(type) || ContainsThorAquaticBoss(type);

    public static bool ContainsCalAquaticBoss(int type) => instance.CalamityModLoaded && CalSets.AquaticBosses.Contains(type);
    public static bool ContainsThorAquaticBoss(int type) => instance.ThoriumModLoaded && ThorSets.AquaticBosses.Contains(type);
    public static bool ContainsVanAquaticBoss(int type) => VanillaSets.AquaticBosses.Contains(type);

    #endregion

    #region HashSet Contains Aquatic Tile

    public static bool HashSetContainsAquaticTile(int type) => ContainsCalAquaticTile(type) || ContainsThorAquaticTile(type);

    public static bool ContainsCalAquaticTile(int type) => instance.CalamityModLoaded && CalSets.IsAquaticTile.Contains(type);
    public static bool ContainsThorAquaticTile(int type) => instance.ThoriumModLoaded && ThorSets.IsAquaticTile.Contains(type);

    #endregion

    #region HashSet Contains Aquatic Wall

    public static bool HashSetContainsCalAquaticWall(int type) => ContainsCalAquaticWall(type) || ContainsThorAquaticWall(type);

    public static bool ContainsCalAquaticWall(int type) => instance.CalamityModLoaded && CalSets.IsAquaticWall.Contains(type);
    public static bool ContainsThorAquaticWall(int type) => instance.ThoriumModLoaded && ThorSets.IsAquaticWall.Contains(type);

    #endregion

}