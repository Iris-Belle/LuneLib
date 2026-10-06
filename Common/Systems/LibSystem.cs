namespace LuneLib.Common.Systems;

public class LLibSysPlr : ModPlayer
{
    public override void OnEnterWorld()
    {
        if (Player.whoAmI != Main.myPlayer)
            return;

        LLibSystem.dayCount = 0;
        LLibSystem.ResetStartup();
    }
}

public class LLibSystem : ModSystem
{
    internal static LLibSystem Instance;

    public override void Load()
    {
        Instance = this;
    }

    public override void Unload()
    {
        Instance = null;
    }

    internal static void ResetStartup()
    {
        if (Instance is null)
            return;

        Instance._timers.Reset(Timers.StartupDelay);

        Instance._once.Reset(Once.StartupMessage);
        Instance._once.Reset(Once.DayMessage);
        Instance._once.Reset(Once.NightMessage);
        Instance._once.Reset(Once.Reset1Message);
        Instance._once.Reset(Once.Reset2Message);

        Instance.wasDay = false;
        Instance.dSent = false;
        Instance.nSent = false;
    }

    private enum Timers
    {
        StartupDelay,
        Day6Reset1Delay,
        Reset2Delay,
    }

    private enum Once
    {
        StartupMessage,
        NightMessage,
        DayMessage,
        Day6SequenceStarted,
        Reset1Message,
        Reset2Message,
    }

    private readonly TimerSet<Timers> _timers = TimerSet<Timers>.ForEnum(true);
    
    private readonly FlagUtils<Once> _once = new();

    private readonly ScreenMessageManager _msgMgr = new();

    private bool
        wasDay,
        dSent,
        nSent;

    internal static int dayCount = 0;

    public override bool IsLoadingEnabled(Mod mod) => _ClientConfig.Days;

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
            nSent = true;
        }

        if (hours == 5 && minutes == 40 && !dSent)
        {
            dSent = true;
        }

        if (isDay && !wasDay)
        {
            if (dayCount != 0)
            {
                dayCount++;

                if (dayCount > 6)
                    dayCount = 1;
            }

            dSent = false;
            nSent = false;

            _once.Reset(Once.DayMessage);
            _once.Reset(Once.NightMessage);
            _once.Reset(Once.Reset1Message);
            _once.Reset(Once.Reset2Message);

            _timers.Reset(Timers.Day6Reset1Delay);
            _timers.Reset(Timers.Reset2Delay);
        }

        wasDay = isDay;

        if (nSent && _once.Once(Once.NightMessage))
        {
            _msgMgr.Enqueue
            (
                text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.Drowsy"),
                textSize: 1.5f,
                startHeight: 300,
                textR: 255, textG: 255, textB: 0, textA: 255,
                bgA: 0,
                lifetimeMs: 7000,
                fadeInTimeMs: 250,
                fadeOutTimeMs: 2000
            );
            if (_ClientConfig.DaysHelpText)
            {
                _msgMgr.Enqueue
                (
                    text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
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

        if (dSent && dayCount != 0 && _once.Once(Once.DayMessage))
        {
            _msgMgr.Enqueue
            (
                text: Language.GetTextValue($"Mods.LuneLib.Messages.Chat.Isle.Day{dayCount}"),
                textSize: 1.5f,
                startHeight: 300,
                textR: 255, textG: 255, textB: 0, textA: 255,
                bgA: 0,
                lifetimeMs: 6000,
                fadeInTimeMs: 0,
                fadeOutTimeMs: 2000
            );

            if (_ClientConfig.DaysHelpText)
            {
                _msgMgr.Enqueue
                (
                    text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
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
                _once.Once(Once.Day6SequenceStarted);
                _timers.Reset(Timers.Day6Reset1Delay);
            }
        }

        if (_once.IsSet(Once.Day6SequenceStarted) && !_once.IsSet(Once.Reset1Message) && _timers.Tick(Timers.Day6Reset1Delay, 450))
        {
            _once.Once(Once.Reset1Message);
            _timers.Reset(Timers.Reset2Delay);

            _msgMgr.Enqueue(
                text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset1"),
                textSize: 1.5f,
                startHeight: 300,
                textR: 7,
                textG: 242,
                textB: 242,
                textA: 255,
                bgA: 0,
                lifetimeMs: 8000,
                fadeInTimeMs: 0,
                fadeOutTimeMs: 2000
            );
        }
        else if (_once.IsSet(Once.Reset1Message) && !_once.IsSet(Once.Reset2Message) && _timers.Tick(Timers.Reset2Delay, 360))
        {
            _once.Once(Once.Reset2Message);

            _msgMgr.Enqueue(
                text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset2"),
                textSize: 1.5f,
                startHeight: 300,
                textR: 7,
                textG: 242,
                textB: 242,
                textA: 255,
                bgA: 0,
                lifetimeMs: 8000,
                fadeInTimeMs: 0,
                fadeOutTimeMs: 2000
            );

            if (_ClientConfig.DaysHelpText)
            {
                _msgMgr.Enqueue(
                    text: Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
                    textSize: 0.75f,
                    startHeight: 350,
                    textR: 165,
                    textG: 0,
                    textB: 35,
                    textA: 255,
                    bgA: 0,
                    lifetimeMs: 8000,
                    fadeInTimeMs: 0,
                    fadeOutTimeMs: 2000,
                    stack: false
                );
            }
        }
        _msgMgr.Draw();
    }
}