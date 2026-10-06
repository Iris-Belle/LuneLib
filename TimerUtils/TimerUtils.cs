namespace LuneLib.TimerUtils;

public static class TimerUtils
{
    #region Fields/Properties

    private static readonly List<Action> _updates = [];
    public static void Register(Action update) => _updates.Add(update);
    public static void Unregister(Action update) => _updates.Remove(update);

    #endregion

    #region Methods

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Repeat(ref uint start, uint end)
    {
        if (++start < end)
            return false;

        start = 0;

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Reset(ref uint time) => time = 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Tick(ref uint time) => ++time;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Tick(ref uint start, uint end) => ++start >= end;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TickOnce(ref uint start, uint end)
    {
        if (start == uint.MaxValue || ++start < end)
            return false;

        start = uint.MaxValue;

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TickOverflow(ref uint start, uint end)
    {
        if (++start < end)
            return false;

        start -= end;

        return true;
    }

    public static void Update()
    {
        for (int i = 0; i < _updates.Count; i++)
            _updates[i]();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Wait(uint start, uint end) => start >= end;

    #endregion
}

public sealed class TimerSet<TEnum> : IDisposable where TEnum : unmanaged, Enum
{
    #region Fields/Properties

    private readonly uint[] _timers;
    private readonly bool _maintime;

    #endregion

    #region Constructors

    private TimerSet(bool maintime)
    {
        _timers = new uint[Enum.GetValues<TEnum>().Length];
        _maintime = maintime;

        if (maintime)
            TimerUtils.Register(MainTime);
    }

    #endregion

    #region Methods

    public void Clear() => Array.Clear(_timers);

    public void Dispose()
    {
        if (_maintime)
            TimerUtils.Unregister(MainTime);
    }

    public static TimerSet<TEnum> ForEnum(bool maintime = false) => new(maintime);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref uint Get(TEnum id) => ref _timers[Unsafe.As<TEnum, int>(ref id)];

    private void MainTime()
    {
        for (int i = 0; i < _timers.Length; i++)
            if (_timers[i] != uint.MaxValue)
                _timers[i]++;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Repeat(TEnum id, uint end)
    {
        ref uint start = ref Get(id);

        if (!_maintime) 
            start++;

        if (start < end)
            return false;

        start = 0;

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset(TEnum id) => Get(id) = 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint Tick(TEnum id)
    {
        ref uint start = ref Get(id);

        if (!_maintime) 
            start++;

        return start;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Tick(TEnum id, uint end)
    {
        ref uint start = ref Get(id);

        if (!_maintime) 
            start++;

        return start >= end;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TickOnce(TEnum id, uint end)
    {
        ref uint start = ref Get(id);

        if (start == uint.MaxValue)
            return false;

        if (!_maintime) start++;

        if (start < end)
            return false;

        start = uint.MaxValue;

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TickOverflow(TEnum id, uint end)
    {
        ref uint start = ref Get(id);

        if (!_maintime) start++;

        if (start < end)
            return false;

        start -= end;

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Wait(TEnum id, uint end) => Get(id) >= end;

    #endregion
}

public sealed class RunOneTimeLib<TEnum> where TEnum : unmanaged, Enum
{
    #region Fields/properties

    private readonly bool[] _ran = new bool[Enum.GetValues<TEnum>().Length];

    #endregion

    #region Methods

    public void Clear() => Array.Clear(_ran);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ref bool Get(TEnum id) => ref _ran[Unsafe.As<TEnum, int>(ref id)];

    public bool Once(TEnum id)
    {
        ref bool ran = ref Get(id);

        if (ran)
            return false;

        ran = true;

        return true;
    }

    public void Reset(TEnum id) => Get(id) = false;

    #endregion
}