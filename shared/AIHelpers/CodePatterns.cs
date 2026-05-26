namespace GameCloud.Shared.AIHelpers;

/// <summary>
/// Common code patterns reference for AI-assisted development.
/// These document the conventions used throughout the SDK.
/// </summary>
public static class CodePatterns
{
    // Pattern: All game data classes should be simple POCOs
    // Example: public class EnemyData { public string Name; public int HP; }

    // Pattern: Use EventBus for cross-system communication
    // Example: EventBus.Publish("player-died", playerData);

    // Pattern: Use SaveManager for persistence
    // Example: SaveManager.Save(gameData, "slot1.json");

    // Pattern: Keep forms thin - logic goes in separate manager classes
    // Example: Form calls CombatManager.ExecuteTurn(), not inline logic

    // Pattern: Use JSON files in Assets/ for game data
    // Example: Load level data from Assets/levels.json

    /// <summary>
    /// Documents the standard file naming convention.
    /// </summary>
    public static readonly string[] NamingConventions =
    {
        "Systems: [Name]Manager.cs (e.g., CombatManager.cs)",
        "Data: [Name]Data.cs (e.g., UnitData.cs)",
        "Forms: [Name]Form.cs (e.g., BattleForm.cs)",
        "Helpers: [Name]Helper.cs (e.g., GridHelper.cs)",
        "Models: [Name].cs (e.g., Character.cs)"
    };
}
