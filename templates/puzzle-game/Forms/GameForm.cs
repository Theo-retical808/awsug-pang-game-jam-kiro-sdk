using PuzzleGame.Levels;
using PuzzleGame.Puzzles;
using PuzzleGame.Mechanics;

namespace PuzzleGame.Forms;

/// <summary>
/// Main game window for the puzzle game.
/// </summary>
public class GameForm : Form
{
    private readonly PuzzlePanel _puzzlePanel;
    private readonly StatusPanel _statusPanel;
    private readonly LevelManager _levelManager;
    private readonly MoveTracker _moveTracker;

    public GameForm()
    {
        Text = "Puzzle Game - GAME CLOUD";
        Size = new Size(800, 650);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(15, 15, 25);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        _moveTracker = new MoveTracker();
        _levelManager = new LevelManager();

        // Puzzle display area
        _puzzlePanel = new PuzzlePanel(_levelManager)
        {
            Location = new Point(10, 10),
            Size = new Size(550, 500)
        };
        _puzzlePanel.OnPuzzleAction += HandlePuzzleAction;

        // Status panel
        _statusPanel = new StatusPanel
        {
            Location = new Point(570, 10),
            Size = new Size(210, 500)
        };

        // Buttons
        var restartBtn = CreateButton("Restart", 10, 530);
        restartBtn.Click += (_, _) => RestartLevel();

        var nextBtn = CreateButton("Next Level", 220, 530);
        nextBtn.Click += (_, _) => NextLevel();

        var undoBtn = CreateButton("Undo", 430, 530);
        undoBtn.Click += (_, _) => UndoMove();

        Controls.Add(_puzzlePanel);
        Controls.Add(_statusPanel);
        Controls.Add(restartBtn);
        Controls.Add(nextBtn);
        Controls.Add(undoBtn);

        LoadLevel();
    }

    private void LoadLevel()
    {
        _levelManager.LoadCurrentLevel();
        _moveTracker.Reset();
        UpdateStatus();
        _puzzlePanel.Invalidate();
    }

    private void HandlePuzzleAction(int x, int y)
    {
        var state = _levelManager.GetCurrentPuzzle();
        if (state == null || state.IsSolved) return;

        state.HandleInput(x, y);
        _moveTracker.AddMove();
        UpdateStatus();
        _puzzlePanel.Invalidate();

        if (state.IsSolved)
        {
            _statusPanel.ShowMessage("Puzzle Solved!");
        }
    }

    private void RestartLevel()
    {
        _levelManager.RestartLevel();
        _moveTracker.Reset();
        UpdateStatus();
        _puzzlePanel.Invalidate();
    }

    private void NextLevel()
    {
        if (_levelManager.HasNextLevel())
        {
            _levelManager.NextLevel();
            LoadLevel();
        }
        else
        {
            _statusPanel.ShowMessage("All levels complete!");
        }
    }

    private void UndoMove()
    {
        var state = _levelManager.GetCurrentPuzzle();
        if (state != null && state.CanUndo)
        {
            state.Undo();
            _moveTracker.UndoMove();
            UpdateStatus();
            _puzzlePanel.Invalidate();
        }
    }

    private void UpdateStatus()
    {
        _statusPanel.UpdateInfo(
            _levelManager.CurrentLevelIndex + 1,
            _levelManager.TotalLevels,
            _moveTracker.MoveCount
        );
    }

    private Button CreateButton(string text, int x, int y)
    {
        return new Button
        {
            Text = text,
            Location = new Point(x, y),
            Size = new Size(200, 40),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(40, 40, 70),
            ForeColor = Color.White,
            Font = new Font("Consolas", 10, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
    }
}
