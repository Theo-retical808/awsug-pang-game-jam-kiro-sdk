namespace VisualNovel.Dialogue;

/// <summary>
/// UI panel that displays dialogue with typewriter effect.
/// </summary>
public class DialoguePanel : Panel
{
    private readonly Label _nameLabel;
    private readonly Label _textLabel;
    private string _fullText = "";
    private int _charIndex = 0;
    private readonly System.Windows.Forms.Timer _typeTimer;

    public int TypeSpeed { get; set; } = 25;
    public bool IsTyping => _charIndex < _fullText.Length;

    public DialoguePanel()
    {
        BackColor = Color.FromArgb(220, 10, 10, 30);
        Padding = new Padding(20);

        _nameLabel = new Label
        {
            ForeColor = Color.Gold,
            Font = new Font("Consolas", 13, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(20, 12)
        };

        _textLabel = new Label
        {
            ForeColor = Color.White,
            Font = new Font("Consolas", 10),
            Location = new Point(20, 42),
            Size = new Size(840, 100),
            AutoSize = false
        };

        Controls.Add(_nameLabel);
        Controls.Add(_textLabel);

        _typeTimer = new System.Windows.Forms.Timer { Interval = TypeSpeed };
        _typeTimer.Tick += TypeTick;
    }

    public void ShowLine(string speaker, string text)
    {
        _nameLabel.Text = speaker;
        _fullText = text;
        _charIndex = 0;
        _textLabel.Text = "";
        _typeTimer.Interval = TypeSpeed;
        _typeTimer.Start();
    }

    public void CompleteText()
    {
        _typeTimer.Stop();
        _charIndex = _fullText.Length;
        _textLabel.Text = _fullText;
    }

    private void TypeTick(object? sender, EventArgs e)
    {
        if (_charIndex < _fullText.Length)
        {
            _charIndex++;
            _textLabel.Text = _fullText[.._charIndex];
        }
        else
        {
            _typeTimer.Stop();
        }
    }
}
