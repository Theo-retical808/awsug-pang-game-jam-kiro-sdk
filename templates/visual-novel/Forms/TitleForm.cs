namespace VisualNovel.Forms;

/// <summary>
/// Title screen with New Game, Load, and Quit options.
/// Customize this for your game's branding.
/// </summary>
public class TitleForm : Form
{
    public TitleForm()
    {
        Text = "Visual Novel - Title";
        Size = new Size(900, 650);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(15, 15, 30);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var titleLabel = new Label
        {
            Text = "YOUR STORY TITLE",
            Font = new Font("Consolas", 28, FontStyle.Bold),
            ForeColor = Color.White,
            AutoSize = true,
            Location = new Point(250, 150)
        };

        var newGameBtn = CreateButton("New Game", 300);
        newGameBtn.Click += (_, _) => StartNewGame();

        var loadBtn = CreateButton("Load Game", 360);
        loadBtn.Click += (_, _) => LoadGame();

        var quitBtn = CreateButton("Quit", 420);
        quitBtn.Click += (_, _) => Application.Exit();

        Controls.Add(titleLabel);
        Controls.Add(newGameBtn);
        Controls.Add(loadBtn);
        Controls.Add(quitBtn);
    }

    private Button CreateButton(string text, int y)
    {
        return new Button
        {
            Text = text,
            Size = new Size(200, 40),
            Location = new Point(350, y),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(40, 40, 60),
            ForeColor = Color.White,
            Font = new Font("Consolas", 11, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
    }

    private void StartNewGame()
    {
        Hide();
        var mainForm = new MainForm();
        mainForm.FormClosed += (_, _) => Show();
        mainForm.Show();
    }

    private void LoadGame()
    {
        // TODO: Implement load game UI
        MessageBox.Show("Load system ready - implement your save slots here!");
    }
}
