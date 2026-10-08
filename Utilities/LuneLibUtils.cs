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
