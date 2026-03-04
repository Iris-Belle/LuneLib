namespace LuneLib.Utilities;

public static class LuneLibUtils
{

    #region run once system

    private const int MAX_RUN_FLAGS = 256;
    private static readonly byte[] runFlags = new byte[MAX_RUN_FLAGS];
    private static readonly byte[] runFlagBuckets = new byte[256];
    private static int runFlagCount = 0;

    /// <summary>
    /// Generates a unique key from caller location
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte GetROTKey(
        [CallerMemberName] string caller = "",
        [CallerLineNumber] int line = 0)
    {
        unchecked
        {
            int hash = caller.Length > 0 ? caller[0] : 0;
            return (byte)(hash ^ line);
        }
    }

    /// <summary>
    /// Runs something one time using a byte key
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RunOneTime(byte key)
    {
        if (runFlagBuckets[key] != 0)
            return false;
        if (runFlagCount < MAX_RUN_FLAGS)
        {
            runFlags[runFlagCount++] = key;
            runFlagBuckets[key] = 1;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Runs something one time
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RunOneTime(
        [CallerMemberName] string caller = "",
        [CallerLineNumber] int line = 0) => RunOneTime(GetROTKey(caller, line));

    /// <summary>
    /// Resets a specific RunOneTime key
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ResetROT(byte key)
    {
        if (runFlagBuckets[key] == 0)
            return;
        runFlagBuckets[key] = 0;
        ref byte flagRef = ref MemoryMarshal.GetArrayDataReference(runFlags);
        for (int i = 0; i < runFlagCount; i++)
        {
            if (Unsafe.Add(ref flagRef, i) == key)
            {
                Unsafe.Add(ref flagRef, i) = runFlags[--runFlagCount];
                return;
            }
        }
    }

    /// <summary>
    /// Resets all RunOneTime flags
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ResetROTAll()
    {
        runFlagCount = 0;
        Array.Clear(runFlagBuckets, 0, 256);
    }

    #endregion

    #region wait system

    private const int TIMER_BUCKETS = 512;
    private const int BUCKET_MASK = TIMER_BUCKETS - 1;
    private const int MAX_TIMERS_PER_BUCKET = 8;

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    private struct Timer
    {
        public ushort Key;
        public ushort Interval;
        public int LastFrame;
    }

    [StructLayout(LayoutKind.Sequential)]
    private unsafe struct TimerBucket
    {
        public fixed ushort Keys[8];
        public fixed ushort Intervals[8];
        public fixed int LastFrames[8];
        public byte Count;
    }

    private static readonly TimerBucket[] timerBuckets = new TimerBucket[TIMER_BUCKETS];
    private static int currentFrame = 0;

    /// <summary>
    /// Increments the frame counter
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Tick() => currentFrame++;

    /// <summary>
    /// Generates a unique timer key from caller location
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort GetTimerKey(
        [CallerMemberName] string caller = "",
        [CallerLineNumber] int line = 0)
    {
        unchecked
        {
            int hash = caller.Length > 0 ? caller[0] : 0;
            return (ushort)((hash << 8) | (line & 0xFF));
        }
    }

    /// <summary>
    /// Wait using a ushort key - O(1) average case
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool WaitNum(ushort key, ushort frames)
    {
        int bucket = key & BUCKET_MASK;
        ref TimerBucket b = ref timerBuckets[bucket];
        int frame = currentFrame;

        unsafe
        {
            for (int i = 0; i < b.Count; i++)
            {
                if (b.Keys[i] == key)
                {
                    int elapsed = frame - b.LastFrames[i];
                    if (elapsed >= b.Intervals[i])
                    {
                        b.LastFrames[i] = frame;
                        return true;
                    }
                    return false;
                }
            }
            if (b.Count < MAX_TIMERS_PER_BUCKET)
            {
                int idx = b.Count++;
                b.Keys[idx] = key;
                b.Intervals[idx] = frames;
                b.LastFrames[idx] = frame;
            }
        }

        return false;
    }

    /// <summary>
    /// Wait for a specified number of frames
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Wait(ushort frames,
        [CallerMemberName] string caller = "",
        [CallerLineNumber] int line = 0)
    {
        ushort key = GetTimerKey(caller, line);
        int bucket = key & BUCKET_MASK;
        ref TimerBucket b = ref timerBuckets[bucket];
        int frame = currentFrame;

        unsafe
        {
            for (int i = 0; i < b.Count; i++)
            {
                if (b.Keys[i] == key)
                {
                    int elapsed = frame - b.LastFrames[i];
                    if (elapsed >= b.Intervals[i])
                    {
                        b.LastFrames[i] = frame;
                        return true;
                    }
                    return false;
                }
            }
            if (b.Count < MAX_TIMERS_PER_BUCKET)
            {
                int idx = b.Count++;
                b.Keys[idx] = key;
                b.Intervals[idx] = frames;
                b.LastFrames[idx] = frame;
            }
        }

        return false;
    }

    /// <summary>
    /// Resets a specific timer by key
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ResetTimer(ushort key)
    {
        int bucket = key & BUCKET_MASK;
        ref TimerBucket b = ref timerBuckets[bucket];

        unsafe
        {
            for (int i = 0; i < b.Count; i++)
            {
                if (b.Keys[i] == key)
                {
                    int last = --b.Count;
                    if (i != last)
                    {
                        b.Keys[i] = b.Keys[last];
                        b.Intervals[i] = b.Intervals[last];
                        b.LastFrames[i] = b.LastFrames[last];
                    }
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Resets all wait timers
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ResetWait()
    {
        for (int i = 0; i < TIMER_BUCKETS; i++)
        {
            timerBuckets[i].Count = 0;
        }
    }

    #endregion

    #region Player

    /// <summary>
    /// Checks for my SteamID for player specific uses
    /// </summary>
    public static bool IrisPlayer => Multiplayer_SID_Check(Main.CurrentPlayer, 0);

    /// <summary>
    /// Checks for a friends SteamID for player specific uses
    /// </summary>
    public static bool MushyPlayer => Multiplayer_SID_Check(Main.CurrentPlayer, 1);

    /// <summary>
    /// Checks for a friends SteamID for player specific uses
    /// </summary>
    public static bool NotGoldArcPlayer => Multiplayer_SID_Check(Main.CurrentPlayer, 2);

    /// <summary>
    /// Checks for my SteamID 
    /// Singleplayer only
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public static bool CheckIris(this Player player) => steamID.ToString() == "76561198818748376" && debug.CheckIris;

    /// <summary>
    /// Checks for my friends SteamID
    /// Singleplayer only
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public static bool CheckMushy(this Player player) => steamID.ToString() == "76561199229515262" && debug.CheckMushy;

    /// <summary>
    /// Checks for my friends SteamID
    /// Singleplayer only
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public static bool CheckNotGoldArc(this Player player) => steamID.ToString() == "76561199519588593" && debug.CheckNotGoldArc;

    public static LibPlayer LibPlayer(this Player player) => player.GetModPlayer<LibPlayer>();
    public static LocalizedText GetText(string key) => Language.GetOrRegister($"Mods.LuneLib.{key}");
    /// <summary>
    /// Checks FOR SteamIDs for me and my friend
    /// Multiplayer compatible
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public static bool Multiplayer_SID_Check(this Player player, byte sender)
    {
        switch (sender)
        {
            case 0:
                if (Main.netMode != NetmodeID.SinglePlayer)
                    return player.whoAmI == PlayerSync.IrisWhoAmI;
                else if (Main.netMode == NetmodeID.SinglePlayer)
                    return player.CheckIris();
                break;
            case 1:
                if (Main.netMode != NetmodeID.SinglePlayer)
                    return player.whoAmI == PlayerSync.MushyWhoAmI;
                else if (Main.netMode == NetmodeID.SinglePlayer)
                    return player.CheckMushy();
                break;
            case 2:
                if (Main.netMode != NetmodeID.SinglePlayer)
                    return player.whoAmI == PlayerSync.NotGoldArcWhoAmI;
                else if (Main.netMode == NetmodeID.SinglePlayer)
                    return player.CheckNotGoldArc();
                break;
            default:
                return false;
        }
        return false;
    }

    public static bool Submerged(this Player player) => Collision.DrownCollision(player.position, player.width, player.height, player.gravDir);

    #endregion

    public static void LogStuff(string msg)
    {
        if (clientConfig.DebugMessages)
        {
            if (Main.dedServ)
                Console.WriteLine($"LuneLib: {msg}");
            else if (Main.gameMenu)
                instance.Logger.Debug($"LuneLib: {Main.myPlayer} {msg}");
            else
                Main.NewText($"LuneLib: {msg}");
        }
    }
}
