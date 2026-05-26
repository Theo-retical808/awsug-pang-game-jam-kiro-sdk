namespace PuzzleGame.Mechanics;

/// <summary>
/// Basic scoring system. Extend with combos, time bonuses, etc.
/// </summary>
public class ScoreSystem
{
    public int Score { get; private set; } = 0;
    public int HighScore { get; private set; } = 0;

    public void AddPoints(int points)
    {
        Score += points;
        if (Score > HighScore)
            HighScore = Score;
    }

    public void Reset()
    {
        Score = 0;
    }

    public int CalculateLevelScore(int moves, int parMoves)
    {
        if (moves <= parMoves)
            return 1000;
        else
            return Math.Max(100, 1000 - (moves - parMoves) * 50);
    }
}
