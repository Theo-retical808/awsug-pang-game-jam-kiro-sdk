using PuzzleGame.Levels;

namespace PuzzleGame.Puzzles;

/// <summary>
/// Renders the current puzzle state as a grid.
/// </summary>
public class PuzzlePanel : Panel
{
    private readonly LevelManager _levelManager;
    private const int CellPadding = 20;

    public event Action<int, int>? OnPuzzleAction;

    public PuzzlePanel(LevelManager levelManager)
    {
        _levelManager = levelManager;
        DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        BackColor = Color.FromArgb(20, 20, 35);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var puzzle = _levelManager.GetCurrentPuzzle();
        if (puzzle == null) return;

        var g = e.Graphics;
        int cellSize = Math.Min(
            (Width - CellPadding * 2) / puzzle.Width,
            (Height - CellPadding * 2) / puzzle.Height
        );

        int offsetX = (Width - cellSize * puzzle.Width) / 2;
        int offsetY = (Height - cellSize * puzzle.Height) / 2;

        for (int x = 0; x < puzzle.Width; x++)
        for (int y = 0; y < puzzle.Height; y++)
        {
            var rect = new Rectangle(
                offsetX + x * cellSize + 2,
                offsetY + y * cellSize + 2,
                cellSize - 4,
                cellSize - 4
            );

            var color = puzzle.GetCellColor(x, y);
            using var brush = new SolidBrush(color);
            g.FillRectangle(brush, rect);

            using var pen = new Pen(Color.FromArgb(60, 70, 90), 1);
            g.DrawRectangle(pen, rect);
        }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        var puzzle = _levelManager.GetCurrentPuzzle();
        if (puzzle == null) return;

        int cellSize = Math.Min(
            (Width - CellPadding * 2) / puzzle.Width,
            (Height - CellPadding * 2) / puzzle.Height
        );

        int offsetX = (Width - cellSize * puzzle.Width) / 2;
        int offsetY = (Height - cellSize * puzzle.Height) / 2;

        int x = (e.X - offsetX) / cellSize;
        int y = (e.Y - offsetY) / cellSize;

        if (x >= 0 && x < puzzle.Width && y >= 0 && y < puzzle.Height)
            OnPuzzleAction?.Invoke(x, y);
    }
}
