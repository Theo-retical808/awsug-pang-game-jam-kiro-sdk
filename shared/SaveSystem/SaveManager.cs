using System.Text.Json;

namespace GameCloud.Shared.SaveSystem;

/// <summary>
/// Generic save/load system using JSON serialization.
/// Works with any serializable data class.
/// </summary>
public static class SaveManager
{
    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static string SaveDirectory { get; set; } = "Saves";

    public static void Save<T>(T data, string fileName)
    {
        EnsureDirectory();
        var path = Path.Combine(SaveDirectory, fileName);
        var json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(path, json);
    }

    public static T? Load<T>(string fileName)
    {
        var path = Path.Combine(SaveDirectory, fileName);
        if (!File.Exists(path)) return default;

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json, _options);
    }

    public static bool SaveExists(string fileName)
    {
        return File.Exists(Path.Combine(SaveDirectory, fileName));
    }

    public static void Delete(string fileName)
    {
        var path = Path.Combine(SaveDirectory, fileName);
        if (File.Exists(path)) File.Delete(path);
    }

    public static List<string> GetAllSaves()
    {
        EnsureDirectory();
        return Directory.GetFiles(SaveDirectory, "*.json")
            .Select(Path.GetFileNameWithoutExtension)
            .Where(n => n != null)
            .Cast<string>()
            .ToList();
    }

    private static void EnsureDirectory()
    {
        if (!Directory.Exists(SaveDirectory))
            Directory.CreateDirectory(SaveDirectory);
    }
}
