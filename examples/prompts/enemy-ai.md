# Enemy AI Prompts

## Aggressive AI
```
In AI/EnemyAI.cs, create AggressiveStrategy:
- Always moves toward weakest player unit
- Attacks immediately when in range
- Ignores own safety
- Prioritizes low-HP targets
```

## Defensive AI
```
In AI/EnemyAI.cs, create DefensiveStrategy:
- Stays near allied units
- Only attacks if enemy comes within range
- Retreats when HP below 30%
- Prioritizes healing allies (if healer)
```

## Boss AI
```
Create AI/BossAI.cs with:
- Phase 1 (HP > 50%): Normal attacks, moves slowly
- Phase 2 (HP <= 50%): Enrages, +50% damage, moves faster
- Special attack every 3 turns (hits area)
- Summons minions at 75% and 25% HP
```

## Flanking AI
```
In AI/EnemyAI.cs, add flanking behavior:
- Calculate positions behind player units
- Move to flank position if possible
- Bonus damage when attacking from behind
- Coordinate with other enemies to surround
```

## Patrol AI
```
Create AI/PatrolBehavior.cs with:
- Define patrol waypoints for each enemy
- Move between waypoints each turn
- Switch to aggressive when player unit is within detection range (3 tiles)
- Return to patrol if player moves away
```
