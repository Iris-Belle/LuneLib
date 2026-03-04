namespace LuneLib.Content.Items;

public class HarHarHarHarHar : ModItem
{
    public override bool IsLoadingEnabled(Mod mod) => LuneLib.serverConfig.FreddyFiveBear;
    public override string Texture => "LuneLib/Assets/Sprites/Items/FreddyFazbear";
    public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<HarHarHar>());
        Item.width = 16;
        Item.height = 16;
        Item.value = 150;
    }

    public override void AddRecipes() => CreateRecipe().
        AddIngredient(ItemID.Silk, 5).
        AddIngredient(ItemID.Cobweb, 10).
        AddTile(TileID.Loom).
        Register();
}
