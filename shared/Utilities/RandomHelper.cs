namespace GameCloud.Shared.Utilities;

/// <summary>
/// Random generation utilities for gameplay variety.
/// </summary>
public static class RandomHelper
{
    public static T PickRandom<T>(IList<T> items)
    {
        if (items.Count == 0)
            throw new ArgumentException("Cannot pick from empty list");

        return items[Random.Shared.Next(items.Count)];
    }

    public static List<T> Shuffle<T>(List<T> items)
    {
        var shuffled = new List<T>(items);
        for (int i = shuffled.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
        }
        return shuffled;
    }

    public static bool Chance(int percentChance)
    {
        return Random.Shared.Next(100) < percentChance;
    }

    public static float RandomFloat(float min = 0f, float max = 1f)
    {
        return min + Random.Shared.NextSingle() * (max - min);
    }
}
