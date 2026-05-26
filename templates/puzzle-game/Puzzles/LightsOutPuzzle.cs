namespace PuzzleGame.Puzzles;

/// <summary>
/// Sample puzzle: Lights Out. Click a cell to toggle it and its neighbors.
/// Goal: Turn all cells off (value = 0).
/// This is just ONE example - create your own puzzle types!
/// </summary>
public class LightsOutPuzzle : PuzzleState
{
    private int[,] _grid;

    public LightsOutPuzzle(int size = 5)
    {
        Width = size;
        Height = size;
        _grid = new int[size, size];
    }

    public override void Initialize()
    {
        // Create a solvable puzzle by making random moves
        _grid = new int[Width, Height];
        var rng = Random.Shared;

        int moves = rng.Next(3, 8);
        for (int i = 0; i < moves; i++)
        {
            ToggleCell(rng.Next(Width), rng.Next(Height), saveHistory: false);
        }

        _history.Clear();
        IsSolved = false;
    }

    public override void HandleInput(int x, int y)
    {
        if (IsSolved) return;
        if (x < 0 || x >= Width || y < 0 || y >= Height) return;

        SaveState();
        ToggleCell(x, y, saveHistory: false);
        CheckSolved();
    }

    public override void CheckSolved()
    {
        for (int x = 0; x < Width; x++)
        for (int y = 0; y < Height; y++)
        {
            if (_grid[x, y] != 0) return;
        }
        IsSolved = true;
    }

    public override int GetCellValue(int x, int y) => _grid[x, y];

    public override Color GetCellColor(int x, int y)
    {
        return _grid[x, y] == 1
            ? Color.FromArgb(255, 220, 50)  // Light ON
            : Color.FromArgb(30, 30, 50);   // Light OFF
    }

    private void ToggleCell(int x, int y, bool saveHistory)
    {
        Toggle(x, y);
        Toggle(x - 1, y);
        Toggle(x + 1, y);
        Toggle(x, y - 1);
        Toggle(x, y + 1);
    }

    private void Toggle(int x, int y)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
            _grid[x, y] = _grid[x, y] == 0 ? 1 : 0;
    }

    protected override int[,] CaptureState()
    {
        var copy = new int[Width, Height];
        Array.Copy(_grid, copy, _grid.Length);
        return copy;
    }

    protected override void RestoreState(int[,] state)
    {
        _grid = state;
    }
}
