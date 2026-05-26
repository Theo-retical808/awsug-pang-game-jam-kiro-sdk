namespace GameCloud.Shared.UIComponents;

/// <summary>
/// A reusable dialogue box component with typewriter effect support.
/// </summary>
public class DialogueBox : Panel
{
    private readonly Label _nameLabel;
    private readonly Label _textLabel;
    private string _fullText = "";
    private int _charIndex = 0;
    private readonly System.Windows.Forms.Timer _typeTimer;

    public int TypeSpeed { get; set; } = 30; // ms per character
    public bool IsTyping => _charIndex < _fullText.Length;
    public event Action? OnTextComplete;

    public DialogueBox()
    {
        BackColor = Color.FromArgb(200, 20, 20, 40);
        Padding = new Padding(15);
        Dock = DockStyle.Bottom;
        Height = 150;

        _nameLabel = new Label
        {
            ForeColor = Color.Gold,
            Font = new Font("Consolas", 12, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(15, 10)
        };

        _textLabel = new Label
        {
            ForeColor = Color.White,
            Font = new Font("Consolas", 10),
            Location = new Point(15, 35),
            Size = new Size(750, 100),
            AutoSize = false
        };

        Controls.Add(_nameLabel);
        Controls.Add(_textLabel);

        _typeTimer = new System.Windows.Forms.Timer { Interval = TypeSpeed };
        _typeTimer.Tick += TypeTimer_Tick;
    }

    public void ShowText(string speaker, string text)
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
        OnTextComplete?.Invoke();
    }

    private void TypeTimer_Tick(object? sender, EventArgs e)
    {
        if (_charIndex < _fullText.Length)
        {
            _charIndex++;
            _textLabel.Text = _fullText[.._charIndex];
        }
        else
        {
            _typeTimer.Stop();
            OnTextComplete?.Invoke();
        }
    }
}
