namespace LuneLib.Common.Players.LuneLibPlayer;

public partial class LibPlayer : ModPlayer
{
    public override void PostUpdate() => ReduceVisionInStorms();

    public void ReduceVisionInStorms()
    {
        float value = 0f;
        float amount = 0.1f;
        if (Player.LibPlayer().StormEyeCovered && Player.whoAmI == Main.myPlayer)
        {
            value = 0.8f;
            amount = 0.1f;
        }
        ScreenObstruction.screenObstruction = MathHelper.Lerp(ScreenObstruction.screenObstruction, value, amount);
    }
}
