namespace LuneLib.Utilities.Hashsets.Vanilla;

public static class VanillaSets
{

    public static readonly HashSet<int> AbyssalProjectiles;

    public static readonly HashSet<int> AbyssalNPCs;

    public static readonly HashSet<int> AquaticBosses;

    static VanillaSets()
    {

        AbyssalProjectiles = CreateVanillaProjSpecificTypes();

        AbyssalNPCs = CreateVanillaNpcSpecificTypes();

        AquaticBosses = CreateVanillaBossSpecificTypes();

    }

    private static HashSet<int> CreateVanillaProjSpecificTypes() =>
    [
            ProjectileID.EyeBeam,
            ProjectileID.SharknadoBolt,
            ProjectileID.Sharknado,
            ProjectileID.Cthulunado,
            ProjectileID.MartianTurretBolt,
            ProjectileID.RainNimbus,
    ];

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
}