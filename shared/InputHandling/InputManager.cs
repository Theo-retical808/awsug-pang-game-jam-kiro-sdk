namespace GameCloud.Shared.InputHandling;

/// <summary>
/// Tracks keyboard input state for game logic.
/// Attach to a Form's KeyDown/KeyUp events.
/// </summary>
public static class InputManager
{
    private static readonly HashSet<Keys> _pressedKeys = new();
    private static readonly HashSet<Keys> _justPressedKeys = new();

    public static void OnKeyDown(Keys key)
    {
        if (!_pressedKeys.Contains(key))
            _justPressedKeys.Add(key);

        _pressedKeys.Add(key);
    }

    public static void OnKeyUp(Keys key)
    {
        _pressedKeys.Remove(key);
        _justPressedKeys.Remove(key);
    }

    public static bool IsKeyDown(Keys key) => _pressedKeys.Contains(key);

    public static bool IsKeyJustPressed(Keys key) => _justPressedKeys.Contains(key);

    public static void ClearFrame()
    {
        _justPressedKeys.Clear();
    }

    public static void Reset()
    {
        _pressedKeys.Clear();
        _justPressedKeys.Clear();
    }
}
