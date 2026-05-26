namespace GameCloud.Shared.AIHelpers;

/// <summary>
/// Reusable prompt templates for AI-assisted development.
/// Use these as starting points when asking AI to generate features.
/// </summary>
public static class PromptTemplates
{
    public static string AddFeature(string featureName, string context) =>
        $"Add a {featureName} system to this game. Context: {context}. " +
        "Keep it modular, in a separate file, and compatible with the existing architecture.";

    public static string RefactorFile(string fileName, string goal) =>
        $"Refactor {fileName} to {goal}. Keep the same public API. " +
        "Don't change other files unless necessary.";

    public static string GenerateData(string dataType, int count) =>
        $"Generate {count} {dataType} entries as JSON. " +
        "Use the existing data format from the project.";

    public static string FixBug(string description) =>
        $"Fix this bug: {description}. " +
        "Explain what caused it and show the minimal fix.";

    public static string AddUI(string componentDescription) =>
        $"Create a WinForms UI component: {componentDescription}. " +
        "Use the project's existing style (dark theme, Consolas font).";
}
