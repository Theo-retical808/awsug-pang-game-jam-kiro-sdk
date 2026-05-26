using TacticalRPG.Units;

namespace TacticalRPG.Grid;

/// <summary>
/// Manages the tactical grid, tile data, and unit positions.
/// </summary>
public class GridManager
{
    public int Width { get; }
    public int Height { get; }
    public GridTile[,] Tiles { get; }
    public List<Unit> Units { get; } = new();

    public GridManager(int width, int height)
    {
        Width = width;
        Height = height;
        Tiles = new GridTile[width, height];

        for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
            Tiles[x, y] = new GridTile(x, y);
    }

    public void SetupDefaultBattle()
    {
        // Player units
        AddUnit(new Unit("Knight", "Player", 30, 8, 4, 3, 1), 1, 3);
        AddUnit(new Unit("Archer", "Player", 20, 10, 2, 2, 3), 0, 5);
        AddUnit(new Unit("Mage", "Player", 18, 12, 2, 2, 2), 1, 6);

        // Enemy units
        AddUnit(new Unit("Goblin", "Enemy", 15, 6, 2, 3, 1), 8, 2);
        AddUnit(new Unit("Orc", "Enemy", 35, 9, 5, 2, 1), 8, 5);
        AddUnit(new Unit("Shaman", "Enemy", 16, 8, 2, 2, 2), 9, 4);
    }

    public void AddUnit(Unit unit, int x, int y)
    {
        unit.X = x;
        unit.Y = y;
        Units.Add(unit);
        Tiles[x, y].Occupant = unit;
    }

    public Unit? GetUnitAt(int x, int y)
    {
        if (!InBounds(x, y)) return null;
        return Tiles[x, y].Occupant;
    }

    public bool MoveUnit(Unit unit, int newX, int newY)
    {
        if (!InBounds(newX, newY)) return false;
        if (Tiles[newX, newY].Occupant != null) return false;
        if (!Tiles[newX, newY].IsWalkable) return false;

        Tiles[unit.X, unit.Y].Occupant = null;
        unit.X = newX;
        unit.Y = newY;
        Tiles[newX, newY].Occupant = unit;
        return true;
    }

    public void RemoveUnit(Unit unit)
    {
        Tiles[unit.X, unit.Y].Occupant = null;
        Units.Remove(unit);
    }

    public bool InBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    public List<(int x, int y)> GetMovableTiles(Unit unit)
    {
        var result = new List<(int, int)>();
        for (int x = 0; x < Width; x++)
        for (int y = 0; y < Height; y++)
        {
            int dist = Math.Abs(x - unit.X) + Math.Abs(y - unit.Y);
            if (dist <= unit.MoveRange && dist > 0 && Tiles[x, y].Occupant == null && Tiles[x, y].IsWalkable)
                result.Add((x, y));
        }
        return result;
    }

    public List<Unit> GetAttackableUnits(Unit attacker)
    {
        var targets = new List<Unit>();
        foreach (var unit in Units)
        {
            if (unit.Faction == attacker.Faction || !unit.IsAlive) continue;
            int dist = Math.Abs(unit.X - attacker.X) + Math.Abs(unit.Y - attacker.Y);
            if (dist <= attacker.AttackRange)
                targets.Add(unit);
        }
        return targets;
    }
}
