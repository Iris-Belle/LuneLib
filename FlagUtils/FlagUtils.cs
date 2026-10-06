namespace LuneLib.FlagUtils;

public sealed class FlagUtils<TEnum> where TEnum : unmanaged, Enum
{
    #region Fields/properties

    internal readonly ulong[] _flags;

    #endregion

    #region Methods

    public FlagUtils() => _flags = new ulong[(Enum.GetValues<TEnum>().Length + 63) >> 6];

    public void Clear() => Array.Clear(_flags);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int Index(TEnum id) => Unsafe.As<TEnum, int>(ref id);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsSet(TEnum id)
    {
        int index = Index(id);

        return (_flags[index >> 6] & (1UL << (index & 63))) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Once(TEnum id)
    {
        int index = Index(id);

        ref ulong bucket = ref _flags[index >> 6];

        ulong mask = 1UL << (index & 63);

        if ((bucket & mask) != 0)
            return false;

        bucket |= mask;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset(TEnum id)
    {
        int index = Index(id);

        _flags[index >> 6] &= ~(1UL << (index & 63));
    }

    #endregion
}