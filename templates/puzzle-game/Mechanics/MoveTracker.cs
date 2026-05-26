namespace PuzzleGame.Mechanics;

/// <summary>
/// Tracks move count for scoring and undo.
/// </summary>
public class MoveTracker
{
    public int MoveCount { get; private set; } = 0;

    public void AddMove() => MoveCount++;

    public void UndoMove()
    {
        if (MoveCount > 0) MoveCount--;
    }

    public void Reset() => MoveCount = 0;
}
