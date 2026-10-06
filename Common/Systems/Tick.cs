namespace LuneLib.Common.Systems
{
    internal class Tick : ModSystem
    {
        public override void PostUpdateEverything()
        {
            TimerUtils.TimerUtils.Update();
        }
    }
}
