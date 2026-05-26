namespace VisualNovel.Scenes;

/// <summary>
/// Data model for a scene. Extend with music, effects, etc.
/// </summary>
public class SceneData
{
    public string Id { get; set; } = "";
    public string BackgroundImage { get; set; } = "";
    public string? MusicTrack { get; set; }
    public List<CharacterPosition> Characters { get; set; } = new();
}

/// <summary>
/// Where a character appears in a scene.
/// </summary>
public class CharacterPosition
{
    public string CharacterId { get; set; } = "";
    public string Position { get; set; } = "center"; // left, center, right
    public string Expression { get; set; } = "neutral";
}
