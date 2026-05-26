namespace GameCloud.Shared.Core;

/// <summary>
/// Base class for all game states. Extend this for your template.
/// </summary>
public abstract class GameState
{
    public string StateName { get; set; } = "Default";
    public DateTime LastUpdated { get; set; } = DateTime.Now;

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
