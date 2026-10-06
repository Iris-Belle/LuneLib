namespace LuneLib.Utilities;

public static class LuneLibUtils
{
    public static bool I4Chance(this UnifiedRandom rand, int percent) => rand.Next(100) < percent;

    public static bool I4InvertedChance(this UnifiedRandom rand, int percent) => rand.Next(100) >= percent;

    public static bool R4Chance(this UnifiedRandom rand, float percent) => rand.NextFloat(0f, 1f) < percent;

    public static bool R4InvertedChance(this UnifiedRandom rand, float percent) => rand.NextFloat(0f, 1f) >= percent;

    public static LibPlayer LibPlayer(this Player player) => player.GetModPlayer<LibPlayer>();

    public static LocalizedText GetText(string key) => Language.GetOrRegister($"Mods.LuneLib.{key}");

    public static bool Submerged(this Player player) => Collision.DrownCollision(player.position, player.width, player.height, player.gravDir);

    public static float Submersion(this Player player)
    {
        Rectangle hitbox = player.Hitbox;

        int minX = hitbox.Left / 16;
        int maxX = (hitbox.Right - 1) / 16;
        int minY = hitbox.Top / 16;
        int maxY = (hitbox.Bottom - 1) / 16;

        float waterArea = 0f;

        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                if (!WorldGen.InWorld(x, y, 1))
                    continue;

                Tile tile = Main.tile[x, y];

                if (tile.LiquidAmount == 0 || tile.LiquidType != LiquidID.Water)
                    continue;

                if (tile.HasTile && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType])
                    continue;

                int liquidHeight = (int)(tile.LiquidAmount / 255f * 16f);
                Rectangle liquidRect = new(x * 16, y * 16 + 16 - liquidHeight, 16, liquidHeight);

                Rectangle overlap = Rectangle.Intersect(hitbox, liquidRect);
                waterArea += overlap.Width * overlap.Height;
            }
        }
        return waterArea / (hitbox.Width * hitbox.Height);
    }

    [JITWhenModsEnabled("CalamityMod")]
    public static bool ZoneAbyss(this Player player, int layer = 0)
    {
        if (!instance.CalamityModLoaded) return false;

        return layer switch
        {
            1 => player.Calamity().ZoneAbyssLayer1,
            2 => player.Calamity().ZoneAbyssLayer2,
            3 => player.Calamity().ZoneAbyssLayer3,
            4 => player.Calamity().ZoneAbyssLayer4,
            _ => player.Calamity().ZoneAbyss,
        };
    }
}
