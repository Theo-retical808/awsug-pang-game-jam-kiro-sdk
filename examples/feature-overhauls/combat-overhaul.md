# Combat System Overhaul Example

## Goal
Transform the basic attack system into a rich tactical combat experience.

## Step-by-Step (5-7 credits)

### Credit 1: Add elemental types
```
Add an Element enum (Fire, Water, Earth, Wind, None) to Units/Unit.cs.
Add a static weakness chart to Combat/CombatResolver.cs.
Apply 1.5x damage on weakness, 0.5x on resistance.
```

### Credit 2: Add status effects
```
Create Combat/StatusEffect.cs with Poison, Stun, and Shield effects.
Each has a duration and per-turn effect.
Add List<StatusEffect> to Unit.cs with Apply/Tick/Remove methods.
```

### Credit 3: Add abilities with cooldowns
```
Give each unit 2 abilities from AbilityDatabase.
Add ability buttons to BattleForm (show cooldown).
Wire ability use through TurnManager.
```

### Credit 4: Add terrain effects
```
Add TerrainType enum to GridTile (Plain, Forest, Water, Mountain).
Forest: +2 DEF. Water: -1 Move. Mountain: impassable.
Color-code tiles in GridPanel based on terrain.
```

### Credit 5: Improve enemy AI
```
In AI/EnemyAI.cs, make enemies consider:
- Element matchups (prefer attacking weak targets)
- Terrain (move to forest for defense)
- Focus fire (multiple enemies target same player unit)
```

## Result
A tactical combat system with depth, strategy, and replayability — built in 5 AI interactions.
