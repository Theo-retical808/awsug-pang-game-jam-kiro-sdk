using System.Text.Json;

namespace VisualNovel.Dialogue;

/// <summary>
/// Manages dialogue flow, script loading, and branching.
/// </summary>
public class DialogueManager
{
    private DialogueScript? _currentScript;
    private int _currentLine = 0;

    public event Action<string, string>? OnDialogueLine;
    public event Action<List<DialogueChoice>>? OnChoicesPresented;
    public event Action<string>? OnSceneChange;
    public event Action? OnScriptEnd;

    private readonly Dictionary<string, DialogueScript> _scripts = new();

    public DialogueManager()
    {
        LoadAllScripts();
    }

    public void LoadScript(string scriptId)
    {
        if (_scripts.TryGetValue(scriptId, out var script))
        {
            _currentScript = script;
            _currentLine = 0;
        }
    }

    public void Advance()
    {
        if (_currentScript == null) return;

        if (_currentLine >= _currentScript.Lines.Count)
        {
            OnScriptEnd?.Invoke();
            return;
        }

        var line = _currentScript.Lines[_currentLine];

        // Handle scene change
        if (!string.IsNullOrEmpty(line.SceneChange))
            OnSceneChange?.Invoke(line.SceneChange);

        // Handle choices
        if (line.Choices != null && line.Choices.Count > 0)
        {
            OnDialogueLine?.Invoke(line.Speaker, line.Text);
            OnChoicesPresented?.Invoke(line.Choices);
            return; // Wait for choice selection
        }

        // Normal dialogue line
        OnDialogueLine?.Invoke(line.Speaker, line.Text);
        _currentLine++;
    }

    public void SelectChoice(DialogueChoice choice)
    {
        _currentLine++; // Move past the choice line
        if (!string.IsNullOrEmpty(choice.JumpToScript))
        {
            LoadScript(choice.JumpToScript);
            _currentLine = choice.JumpToLine;
        }
        Advance();
    }

    private void LoadAllScripts()
    {
        var assetsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Scripts");
        if (!Directory.Exists(assetsPath))
        {
            // Load default placeholder script
            _scripts["intro"] = CreatePlaceholderScript();
            return;
        }

        foreach (var file in Directory.GetFiles(assetsPath, "*.json"))
        {
            var json = File.ReadAllText(file);
            var script = JsonSerializer.Deserialize<DialogueScript>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (script != null)
                _scripts[script.Id] = script;
        }

        // Ensure intro exists
        if (!_scripts.ContainsKey("intro"))
            _scripts["intro"] = CreatePlaceholderScript();
    }

    private static DialogueScript CreatePlaceholderScript()
    {
        return new DialogueScript
        {
            Id = "intro",
            Lines = new List<DialogueLine>
            {
                new() { Speaker = "System", Text = "Welcome to your Visual Novel template!", SceneChange = "default" },
                new() { Speaker = "Guide", Text = "This is a placeholder story. Replace it with your own!" },
                new() { Speaker = "Guide", Text = "Edit the scripts in Assets/Scripts/ or modify DialogueManager.cs." },
                new()
                {
                    Speaker = "Guide",
                    Text = "What would you like to do?",
                    Choices = new List<DialogueChoice>
                    {
                        new() { Text = "Start building my story!", JumpToScript = "ending_a" },
                        new() { Text = "Explore the code first.", JumpToScript = "ending_b" }
                    }
                }
            }
        };
    }
}
