namespace VisualNovel.Dialogue;

/// <summary>
/// Represents a single line of dialogue.
/// </summary>
public class DialogueLine
{
    public string Speaker { get; set; } = "";
    public string Text { get; set; } = "";
    public string? SceneChange { get; set; }
    public List<DialogueChoice>? Choices { get; set; }
}

/// <summary>
/// Represents a player choice in dialogue.
/// </summary>
public class DialogueChoice
{
    public string Text { get; set; } = "";
    public string JumpToScript { get; set; } = "";
    public int JumpToLine { get; set; } = 0;
}

/// <summary>
/// A complete dialogue script (a sequence of lines).
/// </summary>
public class DialogueScript
{
    public string Id { get; set; } = "";
    public List<DialogueLine> Lines { get; set; } = new();
}
