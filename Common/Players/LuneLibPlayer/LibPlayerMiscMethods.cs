namespace LuneLib.Common.Players.LuneLibPlayer;

public partial class LibPlayer : ModPlayer
{
    #region Is Wearing Armor Type?

    #region Is weaing any armour

    public bool WearingFullArmour { get; set; }
    public bool WearingTwoArmourPieces { get; set; }
    public bool WearingOneArmourPiece { get; set; }
    public bool WearingAnyArmour { get; set; }

    internal int PiecesArmour()
    {
        int armourCount = 0;

        for (int i = 0; i < 3; i++)
        {
            if (Player.armor[i].type != ItemID.None)
            {
                armourCount++;
            }
        }

        return armourCount;
    }

    #endregion

    #region Eskimo

    public bool WearingFullEskimo { get; set; }
    public bool WearingTwoEskimoPieces { get; set; }
    public bool WearingOneEskimoPiece { get; set; }
    public bool WearingAnyEskimo { get; set; }

    internal int PiecesEskimoArmour()
    {
        int eskimoCount = 0;

        int[] eskimoIDs = [ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants, ItemID.PinkEskimoHood, ItemID.PinkEskimoCoat, ItemID.PinkEskimoPants];
        for (int i = 0; i < 3; i++)
        {
            if (Array.Exists(eskimoIDs, id => Player.armor[i].type == id))
            {
                eskimoCount++;
            }
        }

        return eskimoCount;
    }

    #endregion

    #region astalite

    public bool WearingAstraliteVisor { get; set; }
    public bool WearingFullAstralite { get; set; }
    public bool WearingTwoAstralitePieces { get; set; }
    public bool WearingOneAstralitePiece { get; set; }
    public bool WearingAnyAstralite { get; set; }

    [JITWhenModsEnabled("SpiritMod")]
    internal int PiecesAstraliteArmour()
    {
        int AstraliteCount = 0;

        if (Player.armor[0].type == ModContent.ItemType<StarMask>())
        {
            AstraliteCount++;
            WearingAstraliteVisor = true;
        }
        else
        {
            WearingAstraliteVisor = false;
        }

        if (Player.armor[1].type == ModContent.ItemType<StarPlate>())
        {
            AstraliteCount++;
        }

        if (Player.armor[2].type == ModContent.ItemType<StarLegs>())
        {
            AstraliteCount++;
        }

        return AstraliteCount;
    }

    #endregion

    #region astronaut

    public bool WearingAstroHelm { get; set; }
    public bool WearingFullAstro { get; set; }
    public bool WearingTwoAstroPieces { get; set; }
    public bool WearingOneAstroPiece { get; set; }
    public bool WearingAnyAstro { get; set; }

    [JITWhenModsEnabled("SpiritMod")]
    internal int PiecesAstroArmour()
    {
        int astroCount = 0;

        if (Player.armor[0].type == ModContent.ItemType<AstronautHelm>())
        {
            astroCount++;
            WearingAstroHelm = true;
        }
        else
        {
            WearingAstroHelm = false;
        }

        if (Player.armor[1].type == ModContent.ItemType<AstronautBody>())
        {
            astroCount++;
        }

        if (Player.armor[2].type == ModContent.ItemType<AstronautLegs>())
        {
            astroCount++;
        }

        return astroCount;
    }

    #endregion

    #region fishbowl

    public bool IsWearingFishBowl { get; set; }

    internal bool WearingFishBowl() => Player.armor[0].type == ItemID.FishBowl;

    #endregion

    #region metal

    public bool WearingFullMetal { get; set; }
    public bool WearingTwoMetalPieces { get; set; }
    public bool WearingOneMetalPiece { get; set; }
    public bool WearingAnyMetal { get; set; }

    internal int IsWearingMetal()
    {
        int num = 0;
        for (int i = 0; i < 3; i++)
        {
            if (VanillaMetallicSets.MetallicArmourSets.Contains(Player.armor[i].type))
            { num++; }
        }
        return num;
    }

    #endregion

    #region Register

    public override void PostUpdateEquips()
    {
        int armourCount = PiecesArmour();

        WearingFullArmour = armourCount == 3;
        WearingTwoArmourPieces = armourCount == 2;
        WearingOneArmourPiece = armourCount == 1;
        WearingAnyArmour = armourCount > 0;

        int eskimoCount = PiecesEskimoArmour();

        WearingFullEskimo = eskimoCount == 3;
        WearingTwoEskimoPieces = eskimoCount == 2;
        WearingOneEskimoPiece = eskimoCount == 1;
        WearingAnyEskimo = eskimoCount > 0;

        IsWearingFishBowl = WearingFishBowl();

        if (instance.SpiritModLoaded)
        {
            int astraliteCount = PiecesAstraliteArmour();

            WearingFullAstro = astraliteCount == 3;
            WearingTwoAstroPieces = astraliteCount == 2;
            WearingOneAstroPiece = astraliteCount == 1;
            WearingAnyAstro = astraliteCount > 0;

            int astroCount = PiecesAstroArmour();

            WearingFullAstro = astroCount == 3;
            WearingTwoAstroPieces = astroCount == 2;
            WearingOneAstroPiece = astroCount == 1;
            WearingAnyAstro = astroCount > 0;
        }
    }

    #endregion

    #region Diving Accessories

    public bool WearingDivingHelm { get; set; }
    public bool WearingDivingGear { get; set; }
    public bool WearingJellyfishDivingGear { get; set; }
    public bool WearingArcticDivingGear { get; set; }
    public bool WearingAbyssalDivingGear { get; set; }
    public bool WearingAbyssalDivingSuit { get; set; }

    public override void UpdateEquips()
    {
        for (int i = 3; i < 10; i++)
        {
            if (!Player.IsItemSlotUnlockedAndUsable(i))
                continue;

            Item item = Player.armor[i];

            if (item == null || item.IsAir)
                continue;

            CheckAccessory(item);
        }
        var slotLoader = LoaderManager.Get<AccessorySlotLoader>();
        var modSlotPlayer = Player.GetModPlayer<ModAccessorySlotPlayer>();

        for (int i = 0; i < modSlotPlayer.SlotCount; i++)
        {
            if (!slotLoader.ModdedIsItemSlotUnlockedAndUsable(i, Player))
                continue;

            Item item = slotLoader.Get(i, Player).FunctionalItem;

            if (item == null || item.IsAir)
                continue;

            CheckAccessory(item);
        }
        Item head = Player.armor[0];

        if (head != null && !head.IsAir && head.type == ItemID.DivingHelmet)
            WearingDivingHelm = true;
    }

    private void CheckAccessory(Item item)
    {
        switch (item.type)
        {
            case ItemID.DivingGear:
                WearingDivingGear = true;
                break;

            case ItemID.JellyfishDivingGear:
                WearingJellyfishDivingGear = true;
                break;

            case ItemID.ArcticDivingGear:
                WearingArcticDivingGear = true;
                break;
        }

        if (ModLoader.HasMod("CalamityMod"))
            CheckCalamityItems(item);
    }

    [JITWhenModsEnabled("CalamityMod")]
    private void CheckCalamityItems(Item item)
    {
        if (item.type == ModContent.ItemType<AbyssalDivingGear>())
            WearingAbyssalDivingGear = true;
        else if (item.type == ModContent.ItemType<AbyssalDivingSuit>())
            WearingAbyssalDivingSuit = true;
    }

    public class DivingAccessoryGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            var pLib = player.GetModPlayer<LibPlayer>();

            switch (item.type)
            {
                case ItemID.DivingGear:
                    pLib.WearingDivingGear = true;
                    break;

                case ItemID.JellyfishDivingGear:
                    pLib.WearingJellyfishDivingGear = true;
                    break;

                case ItemID.ArcticDivingGear:
                    pLib.WearingArcticDivingGear = true;
                    break;
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.DivingHelmet)
                player.GetModPlayer<LibPlayer>().WearingDivingHelm = true;
        }
    }

    [JITWhenModsEnabled("CalamityMod")]
    public class CalamityDivingAccessoryGlobalItem : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
            => ModLoader.HasMod("CalamityMod");

        [JITWhenModsEnabled("CalamityMod")]
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            var pLib = player.GetModPlayer<LibPlayer>();

            if (item.type == ModContent.ItemType<AbyssalDivingGear>())
                pLib.WearingAbyssalDivingGear = true;
            else if (item.type == ModContent.ItemType<AbyssalDivingSuit>())
                pLib.WearingAbyssalDivingSuit = true;
        }
    }

    #endregion

    #endregion
}
