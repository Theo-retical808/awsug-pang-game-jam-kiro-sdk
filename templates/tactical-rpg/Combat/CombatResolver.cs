using TacticalRPG.Units;

namespace TacticalRPG.Combat;

/// <summary>
/// Resolves combat between units. Extend with critical hits, elements, etc.
/// </summary>
public static class CombatResolver
{
    public static int ResolveAttack(Unit attacker, Unit defender)
    {
        int baseDamage = attacker.Attack;
        int defense = defender.Defense;
        int damage = Math.Max(1, baseDamage - defense);

        // Small random variance
        damage += Random.Shared.Next(-1, 2);
        damage = Math.Max(1, damage);

        defender.TakeDamage(damage);
        return damage;
    }

    // Extension point: Add ability-based damage
    public static int ResolveAbility(Unit caster, Unit target, int abilityPower)
    {
        int damage = Math.Max(1, abilityPower - target.Defense / 2);
        target.TakeDamage(damage);
        return damage;
    }
}
