using TacticalRPG.Grid;
using TacticalRPG.Units;

namespace TacticalRPG.Combat;

public enum CombatMode { Select, Move, Attack }

/// <summary>
/// Manages turn order, phases, and win/lose conditions.
/// </summary>
public class TurnManager
{
    private readonly GridManager _grid;
    private List<Unit> _turnOrder = new();
    private int _activeIndex = 0;

    public int CurrentTurn { get; private set; } = 1;
    public string CurrentPhase { get; private set; } = "Player Phase";
    public CombatMode Mode { get; private set; } = CombatMode.Select;

    public event Action? OnTurnChanged;
    public event Action<string>? OnBattleEnd;

    public TurnManager(GridManager grid)
    {
        _grid = grid;
    }

    public void StartBattle()
    {
        _turnOrder = _grid.Units.Where(u => u.Faction == "Player").ToList();
        _activeIndex = 0;
        CurrentPhase = "Player Phase";
        OnTurnChanged?.Invoke();
    }

    public Unit? GetActiveUnit()
    {
        if (_turnOrder.Count == 0) return null;
        if (_activeIndex >= _turnOrder.Count) return null;
        return _turnOrder[_activeIndex];
    }

    public void SetMode(CombatMode mode)
    {
        Mode = mode;
    }

    public void HandleCellAction(int x, int y)
    {
        var activeUnit = GetActiveUnit();
        if (activeUnit == null) return;

        switch (Mode)
        {
            case CombatMode.Move:
                TryMove(activeUnit, x, y);
                break;
            case CombatMode.Attack:
                TryAttack(activeUnit, x, y);
                break;
            case CombatMode.Select:
                SelectUnit(x, y);
                break;
        }
    }

    private void TryMove(Unit unit, int x, int y)
    {
        if (unit.HasMoved) return;
        int dist = Math.Abs(x - unit.X) + Math.Abs(y - unit.Y);
        if (dist <= unit.MoveRange && _grid.MoveUnit(unit, x, y))
        {
            unit.HasMoved = true;
            Mode = CombatMode.Select;
        }
    }

    private void TryAttack(Unit unit, int x, int y)
    {
        if (unit.HasAttacked) return;
        var target = _grid.GetUnitAt(x, y);
        if (target == null || target.Faction == unit.Faction) return;

        int dist = Math.Abs(x - unit.X) + Math.Abs(y - unit.Y);
        if (dist <= unit.AttackRange)
        {
            CombatResolver.ResolveAttack(unit, target);
            unit.HasAttacked = true;
            Mode = CombatMode.Select;

            if (!target.IsAlive)
                _grid.RemoveUnit(target);

            CheckBattleEnd();
        }
    }

    private void SelectUnit(int x, int y)
    {
        var unit = _grid.GetUnitAt(x, y);
        if (unit != null && _turnOrder.Contains(unit))
        {
            _activeIndex = _turnOrder.IndexOf(unit);
            OnTurnChanged?.Invoke();
        }
    }

    public void EndTurn()
    {
        if (CurrentPhase == "Player Phase")
        {
            // Enemy turn
            CurrentPhase = "Enemy Phase";
            ExecuteEnemyTurn();
            CurrentPhase = "Player Phase";
            CurrentTurn++;

            // Reset player units
            foreach (var unit in _grid.Units.Where(u => u.Faction == "Player"))
                unit.ResetTurn();

            _turnOrder = _grid.Units.Where(u => u.Faction == "Player" && u.IsAlive).ToList();
            _activeIndex = 0;
        }

        OnTurnChanged?.Invoke();
    }

    private void ExecuteEnemyTurn()
    {
        // Simple AI: each enemy attacks nearest player if in range, else moves toward nearest
        foreach (var enemy in _grid.Units.Where(u => u.Faction == "Enemy" && u.IsAlive).ToList())
        {
            var targets = _grid.GetAttackableUnits(enemy);
            if (targets.Count > 0)
            {
                CombatResolver.ResolveAttack(enemy, targets[0]);
                if (!targets[0].IsAlive)
                    _grid.RemoveUnit(targets[0]);
            }
        }

        CheckBattleEnd();
    }

    private void CheckBattleEnd()
    {
        var playerAlive = _grid.Units.Any(u => u.Faction == "Player" && u.IsAlive);
        var enemyAlive = _grid.Units.Any(u => u.Faction == "Enemy" && u.IsAlive);

        if (!playerAlive) OnBattleEnd?.Invoke("Defeat!");
        else if (!enemyAlive) OnBattleEnd?.Invoke("Victory!");
    }
}
