namespace LuneLib.Common.Systems;

public class LLibSysPlr : ModPlayer
{
    public override void OnEnterWorld()
    {
        if (Player.whoAmI == Main.myPlayer)
            LLibSystem.dayCount = 1;
    }
}

public class LLibSystem : ModSystem
{
    private readonly ScreenMessageManager _msgMgr = new();

    public override bool IsLoadingEnabled(Mod mod) => clientConfig.Days;

    internal static int
        dayCount = 0,
        TR2A = 255,
        TR1A = 255,
        DCA = 255,
        DA = 255;

    private bool
        wasDay = false,
        day6StartTimerDone = false,
        dSent = false,
        nSent = false,
        TR1Done = false,
        TRReady = false,
        D6Done = false;

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        if (Main.CurrentPlayer.whoAmI != Main.myPlayer)
            return;

        float worldTime = Utils.GetDayTimeAs24FloatStartingFromMidnight();
        int hours = (int)worldTime;
        int minutes = (int)((worldTime - hours) * 60);
        bool isDay = Main.dayTime;

        if (hours == 22 && minutes == 30 && !nSent)
        {
            ResetTimer(1);
            DA = 255;
            nSent = true;
        }
        if (hours == 5 && minutes == 40 && !dSent)
        {
            ResetTimer(2);
            DCA = 255;
            dSent = true;
        }
        if (isDay && !wasDay)
        {
            if (RunOneTime(7))
                dayCount = 1;
            dayCount++;
            dSent = nSent = D6Done = day6StartTimerDone = TRReady = false;
            ResetROT(2);
            ResetROT(4);
            ResetROT(1);
            ResetROT(3);
        }
        wasDay = isDay;

        if (dayCount > 6)
            dayCount = 1;

        if (WaitNum(1, 180))
            DA = Math.Max(0, DA - 1);

        if (WaitNum(2, 180))
            DCA = Math.Max(0, DCA - 1);

        if (WaitNum(3, 360))
            TR1A = Math.Max(0, TR1A - 1);

        if (WaitNum(4, 300))
            TR2A = Math.Max(0, TR2A - 1);

        if (nSent)
        {
            if (RunOneTime(2))
            {
                _msgMgr.Enqueue(
                    text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.Drowsy"),
                    textSize: 1.5f,
                    startHeight: 300,
                    textR: 255, textG: 255, textB: 0, textA: 255,
                    bgA: 0,
                    lifetimeMs: 7000,
                    fadeInTimeMs: 250,
                    fadeOutTimeMs: 2000
                );
                if (clientConfig.dayshelptext)
                {
                    _msgMgr.Enqueue(text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
                        textSize: 0.75f,
                        startHeight: 350,
                        textR: 165, textG: 0, textB: 35, textA: 255,
                        bgA: 0,
                        lifetimeMs: 7000,
                        fadeInTimeMs: 250,
                        fadeOutTimeMs: 2000,
                        stack: false
                        );
                }
            }
        }

        if (dayCount != 0 && dSent)
        {
            if (RunOneTime(1))
            {
                _msgMgr.Enqueue(
                    text: Language.GetTextValue($"Mods.LuneLib.Messages.Chat.Isle.Day{dayCount}"),
                    textSize: 1.5f,
                    startHeight: 300,
                    textR: 255, textG: 255, textB: 0, textA: DCA,
                    bgA: 0,
                    lifetimeMs: 6000,
                    fadeInTimeMs: 0,
                    fadeOutTimeMs: 2000
                );
                if (clientConfig.dayshelptext)
                {
                    _msgMgr.Enqueue(text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
                        textSize: 0.75f,
                        startHeight: 350,
                        textR: 165, textG: 0, textB: 35, textA: 255,
                        bgA: 0,
                        lifetimeMs: 6000,
                        fadeInTimeMs: 0,
                        fadeOutTimeMs: 2000,
                        stack: false
                        );
                }
                if (dayCount == 6)
                {
                    D6Done = true;
                    ResetTimer(5);
                }
            }
        }

        if (D6Done)
            if (WaitNum(5, 450))
                TRReady = true;

        if (dayCount == 6 && TRReady)
        {
            if (RunOneTime(3))
            {
                TR1A = 255;
                ResetTimer(4);
                _msgMgr.Enqueue(
                    text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset1"),
                    textSize: 1.5f,
                    startHeight: 300,
                    textR: 7, textG: 242, textB: 242, textA: TR1A,
                    bgA: 0,
                    lifetimeMs: 8000,
                    fadeInTimeMs: 0,
                    fadeOutTimeMs: 2000

                );
                TR1Done = true;
                ResetTimer(5);
            }
        }

        if (TR1Done)
            if (WaitNum(6, 360))
            {
                day6StartTimerDone = true;
                TR1Done = false;
            }

        if (day6StartTimerDone)
        {
            TR2A = 255;
            ResetTimer(6);
            _msgMgr.Enqueue(
                text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset2"),
                textSize: 1.5f,
                startHeight: 300,
                textR: 7, textG: 242, textB: 242, textA: TR2A,
                bgA: 0,
                lifetimeMs: 8000,
                fadeInTimeMs: 0,
                fadeOutTimeMs: 2000
            );
            if (clientConfig.dayshelptext)
            {
                _msgMgr.Enqueue(text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
                    textSize: 0.75f,
                    startHeight: 350,
                    textR: 165, textG: 0, textB: 35, textA: 255,
                    bgA: 0,
                    lifetimeMs: 8000,
                    fadeInTimeMs: 0,
                    fadeOutTimeMs: 2000,
                    stack: false
                    );
            }
            day6StartTimerDone = false;
        }
        _msgMgr.Draw();
    }
}