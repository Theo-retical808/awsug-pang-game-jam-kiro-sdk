namespace VisualNovel.Characters;

/// <summary>
/// Manages character data and state.
/// </summary>
public class CharacterManager
{
    private readonly Dictionary<string, CharacterData> _characters = new();

    public CharacterManager()
    {
        // Placeholder characters - replace with your own!
        RegisterCharacter(new CharacterData
        {
            Id = "guide",
            Name = "Guide",
            NameColor = Color.Gold
        });

        RegisterCharacter(new CharacterData
        {
            Id = "player",
            Name = "You",
            NameColor = Color.LightBlue
        });
    }

    public void RegisterCharacter(CharacterData character)
    {
        _characters[character.Id] = character;
    }

    public CharacterData? GetCharacter(string id)
    {
        return _characters.TryGetValue(id, out var c) ? c : null;
    }

    public List<CharacterData> GetAllCharacters() => _characters.Values.ToList();
}
