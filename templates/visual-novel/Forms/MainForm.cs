using VisualNovel.Dialogue;
using VisualNovel.Scenes;

namespace VisualNovel.Forms;

/// <summary>
/// Main game window for the visual novel.
/// </summary>
public class MainForm : Form
{
    private readonly DialoguePanel _dialoguePanel;
    private readonly SceneRenderer _sceneRenderer;
    private readonly ChoicePanel _choicePanel;
    private readonly DialogueManager _dialogueManager;

    public MainForm()
    {
        Text = "Visual Novel - GAME CLOUD";
        Size = new Size(900, 650);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.Black;
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        // Scene background renderer
        _sceneRenderer = new SceneRenderer
        {
            Dock = DockStyle.Fill
        };

        // Dialogue panel at bottom
        _dialoguePanel = new DialoguePanel
        {
            Dock = DockStyle.Bottom,
            Height = 160
        };

        // Choice panel (hidden until choices appear)
        _choicePanel = new ChoicePanel();
        _choicePanel.OnChoiceSelected += HandleChoice;

        // Add controls (order matters for z-index)
        Controls.Add(_choicePanel);
        Controls.Add(_dialoguePanel);
        Controls.Add(_sceneRenderer);

        // Initialize dialogue system
        _dialogueManager = new DialogueManager();
        _dialogueManager.OnDialogueLine += ShowDialogue;
        _dialogueManager.OnChoicesPresented += ShowChoices;
        _dialogueManager.OnSceneChange += ChangeScene;

        // Click to advance
        _sceneRenderer.Click += (_, _) => AdvanceDialogue();
        _dialoguePanel.Click += (_, _) => AdvanceDialogue();

        // Start the story
        _dialogueManager.LoadScript("intro");
        _dialogueManager.Advance();
    }

    private void ShowDialogue(string speaker, string text)
    {
        _choicePanel.Hide();
        _dialoguePanel.ShowLine(speaker, text);
    }

    private void ShowChoices(List<DialogueChoice> choices)
    {
        _choicePanel.ShowChoices(choices);
    }

    private void HandleChoice(DialogueChoice choice)
    {
        _dialogueManager.SelectChoice(choice);
    }

    private void ChangeScene(string sceneName)
    {
        _sceneRenderer.LoadScene(sceneName);
    }

    private void AdvanceDialogue()
    {
        if (_dialoguePanel.IsTyping)
        {
            _dialoguePanel.CompleteText();
            return;
        }

        _dialogueManager.Advance();
    }
}
