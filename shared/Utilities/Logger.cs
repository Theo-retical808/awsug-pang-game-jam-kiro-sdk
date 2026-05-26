namespace GameCloud.Shared.Utilities;

/// <summary>
/// Simple logging utility for debugging.
/// </summary>
public static class Logger
{
    public enum LogLevel { Debug, Info, Warning, Error }

    public static LogLevel MinLevel { get; set; } = LogLevel.Debug;

    public static void Debug(string message) => Log(LogLevel.Debug, message);
    public static void Info(string message) => Log(LogLevel.Info, message);
    public static void Warning(string message) => Log(LogLevel.Warning, message);
    public static void Error(string message) => Log(LogLevel.Error, message);

    private static void Log(LogLevel level, string message)
    {
        if (level < MinLevel) return;

        var timestamp = DateTime.Now.ToString("HH:mm:ss");
        var prefix = level switch
        {
            LogLevel.Debug => "[DBG]",
            LogLevel.Info => "[INF]",
            LogLevel.Warning => "[WRN]",
            LogLevel.Error => "[ERR]",
            _ => "[???]"
        };

        Console.WriteLine($"{timestamp} {prefix} {message}");
    }
}
