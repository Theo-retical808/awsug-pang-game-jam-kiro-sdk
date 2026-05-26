using TacticalRPG.Grid;
using TacticalRPG.Units;

namespace TacticalRPG.AI;

/// <summary>
/// Basic enemy AI. Replace with smarter behavior!
/// Current behavior: attack if in range, else move toward nearest player.
/// </summary>
public static class EnemyAI
{
    public static void ExecuteTurn(Unit enemy, GridManager grid)
    {
        // Try to attack first
        var targets = grid.GetAttackableUnits(enemy);
        if (targets.Count > 0)
        {
            var target = GetWeakestTarget(targets);
            Combat.CombatResolver.ResolveAttack(enemy, target);
            if (!target.IsAlive) grid.RemoveUnit(target);
            return;
        }

        // Move toward nearest player unit
        var nearest = GetNearestEnemy(enemy, grid);
        if (nearest != null)
        {
            var moveTiles = grid.GetMovableTiles(enemy);
            if (moveTiles.Count > 0)
            {
                var best = moveTiles.OrderBy(t =>
                    Math.Abs(t.x - nearest.X) + Math.Abs(t.y - nearest.Y)
                ).First();

                grid.MoveUnit(enemy, best.x, best.y);
            }
        }
    }

    private static Unit GetWeakestTarget(List<Unit> targets)
    {
        return targets.OrderBy(t => t.HP).First();
    }

    private static Unit? GetNearestEnemy(Unit unit, GridManager grid)
    {
        return grid.Units
            .Where(u => u.Faction != unit.Faction && u.IsAlive)
            .OrderBy(u => Math.Abs(u.X - unit.X) + Math.Abs(u.Y - unit.Y))
            .FirstOrDefault();
    }
}
