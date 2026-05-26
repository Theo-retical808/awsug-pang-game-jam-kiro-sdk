namespace GameCloud.Shared.Utilities;

/// <summary>
/// Common math utilities for game development.
/// </summary>
public static class MathHelper
{
    public static int Clamp(int value, int min, int max)
    {
        return Math.Max(min, Math.Min(max, value));
    }

    public static float Lerp(float start, float end, float t)
    {
        return start + (end - start) * Math.Clamp(t, 0f, 1f);
    }

    public static int ManhattanDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }

    public static double EuclideanDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public static int RandomRange(int min, int max)
    {
        return Random.Shared.Next(min, max + 1);
    }
}
