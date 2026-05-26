namespace VisualNovel.Characters;

/// <summary>
/// Defines a character in the visual novel.
/// Add portraits, expressions, and metadata here.
/// </summary>
public class CharacterData
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public Color NameColor { get; set; } = Color.White;
    public Dictionary<string, string> Expressions { get; set; } = new(); // expression -> image path
}
