namespace LuneLib.Common.Systems;

internal class Tick : ModPlayer
{
    public override void PostUpdate()
    {
        if (Player.whoAmI == Main.myPlayer)
            Tick();
    }
}
