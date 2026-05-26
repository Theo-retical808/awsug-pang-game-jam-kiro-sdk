namespace VisualNovel.Dialogue;

/// <summary>
/// Displays branching choices to the player.
/// </summary>
public class ChoicePanel : Panel
{
    public event Action<DialogueChoice>? OnChoiceSelected;

    public ChoicePanel()
    {
        BackColor = Color.Transparent;
        Size = new Size(400, 300);
        Location = new Point(250, 200);
        Visible = false;
    }

    public void ShowChoices(List<DialogueChoice> choices)
    {
        Controls.Clear();
        Visible = true;

        int y = 0;
        foreach (var choice in choices)
        {
            var btn = new Button
            {
                Text = choice.Text,
                Size = new Size(380, 45),
                Location = new Point(10, y),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(200, 30, 30, 60),
                ForeColor = Color.White,
                Font = new Font("Consolas", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = choice
            };

            btn.FlatAppearance.BorderColor = Color.FromArgb(100, 150, 255);
            btn.Click += ChoiceClicked;
            Controls.Add(btn);
            y += 55;
        }

        Height = y + 10;
    }

    private void ChoiceClicked(object? sender, EventArgs e)
    {
        if (sender is Button btn && btn.Tag is DialogueChoice choice)
        {
            Visible = false;
            OnChoiceSelected?.Invoke(choice);
        }
    }

    public new void Hide()
    {
        Visible = false;
        Controls.Clear();
    }
}
