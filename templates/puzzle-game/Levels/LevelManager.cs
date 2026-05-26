using PuzzleGame.Puzzles;

namespace PuzzleGame.Levels;

/// <summary>
/// Manages level progression. Add more levels or generate them procedurally!
/// </summary>
public class LevelManager
{
    private readonly List<Func<PuzzleState>> _levelFactories = new();
    private PuzzleState? _currentPuzzle;

    public int CurrentLevelIndex { get; private set; } = 0;
    public int TotalLevels => _levelFactories.Count;

    public LevelManager()
    {
        // Register levels - add more here or generate procedurally!
        _levelFactories.Add(() => new LightsOutPuzzle(3)); // Easy
        _levelFactories.Add(() => new LightsOutPuzzle(4)); // Medium
        _levelFactories.Add(() => new LightsOutPuzzle(5)); // Hard
    }

    public void LoadCurrentLevel()
    {
        if (CurrentLevelIndex < _levelFactories.Count)
        {
            _currentPuzzle = _levelFactories[CurrentLevelIndex]();
            _currentPuzzle.Initialize();
        }
    }

    public PuzzleState? GetCurrentPuzzle() => _currentPuzzle;

    public void RestartLevel()
    {
        LoadCurrentLevel();
    }

    public bool HasNextLevel() => CurrentLevelIndex < _levelFactories.Count - 1;

    public void NextLevel()
    {
        if (HasNextLevel())
        {
            CurrentLevelIndex++;
            LoadCurrentLevel();
        }
    }

    public void AddLevel(Func<PuzzleState> factory)
    {
        _levelFactories.Add(factory);
    }
}
