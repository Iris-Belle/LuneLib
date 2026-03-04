namespace LuneLib.Utilities;

/// <summary>
/// Manages on-screen messages: queuing, stacking, fading in and out, and expiration
/// Includes logarithmic transitions for smooth stacking :3c
/// </summary>
public class ScreenMessageManager
{
    private class MessageEntry
    {
        public string Text;
        public float TextSize;
        public Vector2 Position;
        public float CurrentY;
        public float TargetY;
        public string Key;
        public Color TextColor;
        public Color BgColor;
        public int Lifetime;
        public int FadeInTime;
        public int FadeOutTime;
        public int StartTime;
    }

    private static Texture2D _background;
    private readonly List<MessageEntry> _messages = [];
    public static readonly Dictionary<string, double> VelocityKeys = [];
    public static readonly Dictionary<string, double> Results = [];
    public static readonly Dictionary<string, bool> LogarithmicComplete = [];
    private static readonly Dictionary<string, DateTime> LastUpdateTime = [];

    /// <summary>
    /// Logarithmically transitions one number to another :3
    /// key is a unique string you have to give :3
    /// </summary>
    public static double LogarithmicTransition(string key, int startPosition, int targetPosition, double smoothing = 0.1)
    {
        smoothing = MathHelper.Clamp((float)smoothing, 0.01f, 1f);
        DateTime currentTime = DateTime.UtcNow;
        if (!LastUpdateTime.TryGetValue(key, out DateTime value))
        {
            value = currentTime;
            LastUpdateTime[key] = value;
            Results[key] = startPosition;
            LogarithmicComplete[key] = false;
        }
        double elapsed = (currentTime - value).TotalSeconds;
        if (elapsed <= 0)
            return Results[key];
        LastUpdateTime[key] = currentTime;
        if (LogarithmicComplete[key])
            return Results[key];
        double current = Results[key];
        double delta = targetPosition - current;
        double step = delta * smoothing;
        current += step;
        if (Math.Abs(delta) < 0.5)
        {
            current = targetPosition;
            LogarithmicComplete[key] = true;
        }

        Results[key] = current;
        return current;
    }

    /// <summary>
    /// Queue a new screen message :3
    /// </summary>
    public void Enqueue(
        string text,
        float textSize,
        int startHeight,
        int lifetimeMs,
        int fadeInTimeMs,
        int fadeOutTimeMs,
        int spacing = 3,
        int textR = 0, int textG = 0, int textB = 0, int textA = 255,
        int bgA = 255, int bgR = 0, int bgG = 0, int bgB = 0,
        bool stack = true)
    {
        if (_background == null)
        {
            _background = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
            _background.SetData([Color.White]);
        }
        float baseY = (Main.screenHeight / 2) + startHeight;
        Vector2 newSize = FontAssets.MouseText.Value.MeasureString(text) * textSize;
        float newY = baseY;
        string key = Guid.NewGuid().ToString();
        MessageEntry entry = new()
        {
            Text = text,
            TextSize = textSize,
            Position = new Vector2(Main.screenWidth / 2, newY),
            CurrentY = newY,
            TargetY = newY,
            Key = key,
            TextColor = new Color(textR, textG, textB) * (textA / 255f),
            BgColor = new Color(bgR, bgG, bgB, bgA),
            Lifetime = lifetimeMs,
            FadeInTime = fadeInTimeMs,
            FadeOutTime = fadeOutTimeMs,
            StartTime = Environment.TickCount
        };
        Results[key] = newY;
        VelocityKeys[key] = 5.0;
        LogarithmicComplete[key] = true;
        LastUpdateTime[key] = DateTime.UtcNow;
        _messages.Insert(0, entry);
        if (!stack)
            return;
        float offsetY = -(newSize.Y + spacing);
        foreach (MessageEntry msg in _messages)
        {
            if (msg.Key == key)
                continue;
            float target = baseY + offsetY;
            msg.TargetY = target;
            LogarithmicComplete[msg.Key] = false;
            Results[msg.Key] = msg.CurrentY;
            VelocityKeys[msg.Key] = 5.0;
            LastUpdateTime[msg.Key] = DateTime.UtcNow;
            offsetY -= (FontAssets.MouseText.Value.MeasureString(msg.Text) * msg.TextSize).Y + spacing;
        }
    }

    /// <summary>
    /// Call each frame to draw and update all queued messages :3
    /// </summary>
    public void Draw()
    {
        if (_background == null || _messages.Count == 0)
            return;

        Main.spriteBatch.Begin(
            SpriteSortMode.Deferred,
            BlendState.AlphaBlend,
            SamplerState.PointClamp,
            DepthStencilState.None,
            RasterizerState.CullCounterClockwise,
            null,
            Main.UIScaleMatrix);
        try
        {
            int now = Environment.TickCount;
            for (int i = _messages.Count - 1; i >= 0; i--)
            {
                MessageEntry msg = _messages[i];
                int elapsed = now - msg.StartTime;
                if (elapsed >= msg.Lifetime)
                {
                    _messages.RemoveAt(i);
                    continue;
                }
                if (!LogarithmicComplete[msg.Key])
                    msg.CurrentY = (float)LogarithmicTransition(msg.Key, (int)msg.CurrentY, (int)msg.TargetY, 0.03);

                msg.Position = new Vector2(msg.Position.X, msg.CurrentY);
                float fadeFactor = 1f;
                if (elapsed < msg.FadeInTime)
                    fadeFactor = MathHelper.Clamp(elapsed / (float)msg.FadeInTime, 0f, 1f);
                else if (elapsed >= msg.Lifetime - msg.FadeOutTime)
                {
                    int fadeOutElapsed = elapsed - (msg.Lifetime - msg.FadeOutTime);
                    fadeFactor = 1f - MathHelper.Clamp(fadeOutElapsed / (float)msg.FadeOutTime, 0f, 1f);
                }
                Vector2 size = FontAssets.MouseText.Value.MeasureString(msg.Text) * msg.TextSize;
                Vector2 drawPos = new(msg.Position.X - (size.X / 2), msg.Position.Y);
                Color textColor = msg.TextColor * fadeFactor;
                Color bgColor = msg.BgColor * fadeFactor;
                if (bgColor.A > 0)
                    Main.spriteBatch.Draw(_background, new Rectangle(0, 0, Main.screenWidth + 32, Main.screenHeight + 32), bgColor);
                Main.spriteBatch.DrawString(
                    FontAssets.MouseText.Value,
                    msg.Text,
                    drawPos,
                    textColor,
                    0f,
                    Vector2.Zero,
                    msg.TextSize,
                    SpriteEffects.None,
                    0f);
            }
        }
        finally
        {
            Main.spriteBatch.End();
        }
    }
}
