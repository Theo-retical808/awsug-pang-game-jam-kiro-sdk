namespace PuzzleGame.Forms;

/// <summary>
/// Displays level info, move count, and messages.
/// </summary>
public class StatusPanel : Panel
{
    private readonly Label _levelLabel;
    private readonly Label _movesLabel;
    private readonly Label _messageLabel;

    public StatusPanel()
    {
        BackColor = Color.FromArgb(25, 25, 40);
        BorderStyle = BorderStyle.FixedSingle;

        _levelLabel = new Label
        {
            ForeColor = Color.Gold,
            Font = new Font("Consolas", 12, FontStyle.Bold),
            Location = new Point(10, 15),
            AutoSize = true,
            Text = "Level 1"
        };

        _movesLabel = new Label
        {
            ForeColor = Color.White,
            Font = new Font("Consolas", 10),
            Location = new Point(10, 50),
            AutoSize = true,
            Text = "Moves: 0"
        };

        _messageLabel = new Label
        {
            ForeColor = Color.LimeGreen,
            Font = new Font("Consolas", 10, FontStyle.Bold),
            Location = new Point(10, 100),
            Size = new Size(190, 60),
            AutoSize = false,
            Text = ""
        };

        Controls.Add(_levelLabel);
        Controls.Add(_movesLabel);
        Controls.Add(_messageLabel);
    }

    public void UpdateInfo(int level, int totalLevels, int moves)
    {
        _levelLabel.Text = $"Level {level}/{totalLevels}";
        _movesLabel.Text = $"Moves: {moves}";
        _messageLabel.Text = "";
    }

    public void ShowMessage(string message)
    {
        _messageLabel.Text = message;
    }
}
