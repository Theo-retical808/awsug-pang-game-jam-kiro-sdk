namespace TacticalRPG.Abilities;

/// <summary>
/// Predefined abilities. Add your own here!
/// </summary>
public static class AbilityDatabase
{
    public static Ability Slash => new()
    {
        Name = "Slash",
        Description = "A basic melee attack",
        Power = 8,
        Range = 1,
        Cooldown = 0,
        TargetType = AbilityTarget.Enemy
    };

    public static Ability Fireball => new()
    {
        Name = "Fireball",
        Description = "Ranged fire magic",
        Power = 12,
        Range = 3,
        Cooldown = 2,
        TargetType = AbilityTarget.Enemy
    };

    public static Ability Heal => new()
    {
        Name = "Heal",
        Description = "Restore HP to an ally",
        Power = 10,
        Range = 2,
        Cooldown = 3,
        TargetType = AbilityTarget.Ally
    };

    public static Ability PowerShot => new()
    {
        Name = "Power Shot",
        Description = "Long range piercing arrow",
        Power = 10,
        Range = 4,
        Cooldown = 1,
        TargetType = AbilityTarget.Enemy
    };

    // Add more abilities here!
}
