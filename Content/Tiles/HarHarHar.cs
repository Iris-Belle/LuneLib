namespace LuneLib.Content.Tiles;

public class HarHarHar : ModTile
{
    public override string Texture => "LuneLib/Assets/Sprites/Tiles/FreddyFazbearTile";
    public override void SetStaticDefaults()
    {
        Main.tileTable[Type] = false;
        Main.tileSolidTop[Type] = false;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        TileID.Sets.IgnoredByNpcStepUp[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.CoordinateHeights = [16, 16, 16, 16];
        TileObjectData.addTile(Type);
    }

    public override void NumDust(int x, int y, bool fail, ref int num) => num = fail ? 1 : 3;
}