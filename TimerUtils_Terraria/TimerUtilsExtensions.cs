namespace LuneLib.TimerUtils_Terraria;

public sealed class TimerUtilsExtensions
{
    #region Fields/Properties

    private readonly Dictionary<Type, object> _sets = [];

    #endregion

    #region Methods

    public IEnumerable<KeyValuePair<Type, object>> Timers => _sets;

    public void Clear()
    {
        foreach (object obj in _sets.Values)
        {
            if (obj is IDisposable disposable)
                disposable.Dispose();
        }

        _sets.Clear();
    }

    public TimerSet<T> Get<T>() where T : unmanaged, Enum
    {
        if (!_sets.TryGetValue(typeof(T), out object value))
        {
            value = TimerSet<T>.ForEnum();
            _sets.Add(typeof(T), value);
        }

        return (TimerSet<T>)value;
    }

    #endregion
}

public class ItemTimers : GlobalItem
{
    #region Fields/Properties

    public TimerUtilsExtensions Timers { get; private set; } = new();

    #endregion

    #region Methods

    public override bool InstancePerEntity => true;

    public override GlobalItem Clone(Item from, Item to)
    {
        var clone = (ItemTimers)base.Clone(from, to);
        clone.Timers = new();
        return clone;
    }

    #endregion
}

public class NPCTimers : GlobalNPC
{
    #region Fields/Properties

    public TimerUtilsExtensions Timers { get; private set; } = new();

    #endregion

    #region Methods

    public override bool InstancePerEntity => true;

    public override GlobalNPC Clone(NPC from, NPC to)
    {
        var clone = (NPCTimers)base.Clone(from, to);
        clone.Timers = new();
        return clone;
    }

    #endregion
}

public class ProjectileTimers : GlobalProjectile
{
    #region Fields/Properties

    public TimerUtilsExtensions Timers { get; private set; } = new();

    #endregion

    #region Methods

    public override bool InstancePerEntity => true;

    public override GlobalProjectile Clone(Projectile from, Projectile to)
    {
        var clone = (ProjectileTimers)base.Clone(from, to);
        clone.Timers = new();
        return clone;
    }

    #endregion
}