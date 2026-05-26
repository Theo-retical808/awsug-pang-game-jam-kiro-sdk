namespace TacticalRPG.Units;

/// <summary>
/// Creates predefined unit types. Add your own unit templates here.
/// </summary>
public static class UnitFactory
{
    public static Unit CreateKnight(string faction) =>
        new("Knight", faction, 30, 8, 5, 3, 1);

    public static Unit CreateArcher(string faction) =>
        new("Archer", faction, 20, 10, 2, 2, 3);

    public static Unit CreateMage(string faction) =>
        new("Mage", faction, 18, 12, 2, 2, 2);

    public static Unit CreateGoblin() =>
        new("Goblin", "Enemy", 15, 6, 2, 3, 1);

    public static Unit CreateOrc() =>
        new("Orc", "Enemy", 35, 9, 5, 2, 1);

    public static Unit CreateShaman() =>
        new("Shaman", "Enemy", 16, 8, 2, 2, 2);

    // Add more unit types here!
    // Example: public static Unit CreateDragon() => new("Dragon", "Enemy", 80, 15, 8, 1, 2);
}
