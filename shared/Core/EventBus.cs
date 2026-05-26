namespace GameCloud.Shared.Core;

/// <summary>
/// Simple event bus for decoupled communication between systems.
/// </summary>
public static class EventBus
{
    private static readonly Dictionary<string, List<Action<object?>>> _listeners = new();

    public static void Subscribe(string eventName, Action<object?> handler)
    {
        if (!_listeners.ContainsKey(eventName))
            _listeners[eventName] = new List<Action<object?>>();

        _listeners[eventName].Add(handler);
    }

    public static void Unsubscribe(string eventName, Action<object?> handler)
    {
        if (_listeners.ContainsKey(eventName))
            _listeners[eventName].Remove(handler);
    }

    public static void Publish(string eventName, object? data = null)
    {
        if (_listeners.ContainsKey(eventName))
        {
            foreach (var handler in _listeners[eventName].ToList())
                handler(data);
        }
    }

    public static void Clear()
    {
        _listeners.Clear();
    }
}
