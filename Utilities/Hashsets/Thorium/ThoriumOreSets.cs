namespace LuneLib.Utilities.Hashsets.Thorium;

[JITWhenModsEnabled("ThoriumMod")]
public static class ThoriumOreSets
{
    public static readonly HashSet<int> ThoriumOreSet;

    static ThoriumOreSets()
    {
        if (LuneLib.instance.ThoriumModLoaded)
        {
            ThoriumOreSet = LuneLib.instance.ThoriumModLoaded ? CreateThoriumOreSet() : [];
        }
    }

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