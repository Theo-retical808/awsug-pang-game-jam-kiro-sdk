# Combat System Prompts

## Critical Hit System
```
In Combat/CombatResolver.cs, add critical hits:
- 15% base crit chance
- Crits deal 2x damage, ignoring defense
- Return whether the hit was critical
- Update InfoPanel to show "CRITICAL!" in red when it happens
```

## Status Effects
```
Create Combat/StatusEffect.cs with:
- StatusEffect class: name, duration, effect type
- Types: Poison (damage per turn), Stun (skip turn), Shield (+defense)
- Apply/Remove/Tick methods
- Add a StatusEffects list to Unit.cs
```

## Elemental System
```
Create Combat/ElementSystem.cs with:
- Elements: Fire, Water, Earth, Wind
- Weakness chart (Fire > Earth > Wind > Water > Fire)
- 1.5x damage when hitting weakness
- 0.5x damage when hitting resistance
- Add Element property to Unit.cs
```

## Combo System
```
Create Combat/ComboTracker.cs with:
- Track consecutive hits without missing
- Combo multiplier: 1x, 1.2x, 1.5x, 2x at 0, 2, 4, 6 hits
- Reset on miss or turn end
- Display combo count in InfoPanel
```

## Counterattack
```
In Combat/CombatResolver.cs, add counterattack:
- 25% chance to counter when attacked
- Counter deals 50% of normal damage
- Only melee units can counter
- Show "Counter!" message
```
