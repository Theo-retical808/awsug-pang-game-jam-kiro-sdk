namespace PuzzleGame.Levels;

/// <summary>
/// Data model for level metadata. Use for scoring, stars, etc.
/// </summary>
public class LevelData
{
    public int LevelNumber { get; set; }
    public string Name { get; set; } = "";
    public int ParMoves { get; set; } = 10; // Target moves for best score
    public bool IsCompleted { get; set; }
    public int BestMoves { get; set; } = int.MaxValue;

    public int GetStarRating()
    {
        if (!IsCompleted) return 0;
        if (BestMoves <= ParMoves) return 3;
        if (BestMoves <= ParMoves * 1.5) return 2;
        return 1;
    }
}
