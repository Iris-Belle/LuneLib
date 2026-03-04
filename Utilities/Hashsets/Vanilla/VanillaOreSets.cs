namespace LuneLib.Utilities.Hashsets.Vanilla;

public static class VanillaOreSets
{
    public static readonly HashSet<int> VanillaOres;

    static VanillaOreSets() => VanillaOres = CreateVanillaOresSet();

    private static HashSet<int> CreateVanillaOresSet() =>
    [
        #region prehardmode
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
}