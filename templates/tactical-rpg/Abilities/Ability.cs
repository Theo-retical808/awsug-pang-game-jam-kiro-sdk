namespace TacticalRPG.Abilities;

/// <summary>
/// Base ability definition. Create new abilities by adding instances.
/// </summary>
public class Ability
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Power { get; set; } = 5;
    public int Range { get; set; } = 1;
    public int Cooldown { get; set; } = 0;
    public int CurrentCooldown { get; set; } = 0;
    public AbilityTarget TargetType { get; set; } = AbilityTarget.Enemy;

    public bool IsReady => CurrentCooldown <= 0;

    public void Use()
    {
        CurrentCooldown = Cooldown;
    }

    public void TickCooldown()
    {
        if (CurrentCooldown > 0) CurrentCooldown--;
    }
}

public enum AbilityTarget
{
    Enemy,
    Ally,
    Self,
    Area
}
