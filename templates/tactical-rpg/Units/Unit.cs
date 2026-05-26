namespace TacticalRPG.Units;

/// <summary>
/// Represents a unit on the battlefield.
/// Extend with abilities, status effects, equipment, etc.
/// </summary>
public class Unit
{
    public string Name { get; set; }
    public string Faction { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int MoveRange { get; set; }
    public int AttackRange { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool HasMoved { get; set; }
    public bool HasAttacked { get; set; }
    public bool IsAlive => HP > 0;

    public Unit(string name, string faction, int maxHp, int attack, int defense, int moveRange, int attackRange)
    {
        Name = name;
        Faction = faction;
        MaxHP = maxHp;
        HP = maxHp;
        Attack = attack;
        Defense = defense;
        MoveRange = moveRange;
        AttackRange = attackRange;
    }

    public void TakeDamage(int damage)
    {
        int actualDamage = Math.Max(1, damage - Defense);
        HP = Math.Max(0, HP - actualDamage);
    }

    public void ResetTurn()
    {
        HasMoved = false;
        HasAttacked = false;
    }
}
