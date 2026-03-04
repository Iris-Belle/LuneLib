namespace LuneLib.Utilities.Hashsets.Spirit;

[JITWhenModsEnabled("SpiritMod")]
public static class SpiritOreSets
{
    public static readonly HashSet<int> SpiritOreSet;

    static SpiritOreSets()
    {
        if (LuneLib.instance.SpiritModLoaded)
        {
            SpiritOreSet = LuneLib.instance.SpiritModLoaded ? CreateSpiritOreSet() : [];
        }
    }

    private static HashSet<int> CreateSpiritOreSet() =>
    [
        // prehardmode
        ModContent.TileType<BismiteCrystalTile>(),// no clue which one it is so im adding both
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