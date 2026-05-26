using System.Text.Json;

namespace GameCloud.Shared.Core;

/// <summary>
/// Simple configuration loader. Reads JSON config files.
/// </summary>
public static class GameConfig
{
    private static Dictionary<string, JsonElement> _config = new();

    public static void Load(string filePath)
    {
        if (!File.Exists(filePath)) return;

        var json = File.ReadAllText(filePath);
        var doc = JsonDocument.Parse(json);

        foreach (var prop in doc.RootElement.EnumerateObject())
        {
            _config[prop.Name] = prop.Value.Clone();
        }
    }

    public static string GetString(string key, string defaultValue = "")
    {
        return _config.TryGetValue(key, out var val) ? val.GetString() ?? defaultValue : defaultValue;
    }

    public static int GetInt(string key, int defaultValue = 0)
    {
        return _config.TryGetValue(key, out var val) ? val.GetInt32() : defaultValue;
    }

    public static bool GetBool(string key, bool defaultValue = false)
    {
        return _config.TryGetValue(key, out var val) ? val.GetBoolean() : defaultValue;
    }
}
