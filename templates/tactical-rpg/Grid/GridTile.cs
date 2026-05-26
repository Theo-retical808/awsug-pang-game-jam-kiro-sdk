using TacticalRPG.Units;

namespace TacticalRPG.Grid;

/// <summary>
/// Represents a single tile on the tactical grid.
/// Extend with terrain types, elevation, etc.
/// </summary>
public class GridTile
{
    public int X { get; }
    public int Y { get; }
    public bool IsWalkable { get; set; } = true;
    public string Terrain { get; set; } = "plain";
    public Unit? Occupant { get; set; }

    public GridTile(int x, int y)
    {
        X = x;
        Y = y;
    }
}
