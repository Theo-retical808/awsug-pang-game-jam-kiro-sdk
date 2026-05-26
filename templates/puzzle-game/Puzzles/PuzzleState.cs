namespace PuzzleGame.Puzzles;

/// <summary>
/// Base class for all puzzle types. Implement your own puzzle logic!
/// </summary>
public abstract class PuzzleState
{
    public int Width { get; protected set; }
    public int Height { get; protected set; }
    public bool IsSolved { get; protected set; }
    public bool CanUndo => _history.Count > 0;

    protected Stack<int[,]> _history = new();

    public abstract void Initialize();
    public abstract void HandleInput(int x, int y);
    public abstract void CheckSolved();
    public abstract int GetCellValue(int x, int y);
    public abstract Color GetCellColor(int x, int y);

    public virtual void Undo()
    {
        if (_history.Count > 0)
        {
            RestoreState(_history.Pop());
            IsSolved = false;
        }
    }

    protected abstract void RestoreState(int[,] state);
    protected abstract int[,] CaptureState();

    protected void SaveState()
    {
        _history.Push(CaptureState());
    }
}
