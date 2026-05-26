# Balancing Prompts

## Stat Rebalance
```
In Units/UnitFactory.cs, rebalance all units:
- Knight: high HP/DEF, low ATK, short range (tank)
- Archer: medium HP, high ATK, long range, low DEF (glass cannon)
- Mage: low HP, highest ATK, medium range, area effects
- Ensure no unit is strictly better than another
- Each should have a clear role and weakness
```

## Difficulty Curve
```
Create Balance/DifficultyManager.cs with:
- Level 1-3: Tutorial difficulty (enemies have 50% stats)
- Level 4-6: Normal (enemies at 100%)
- Level 7-9: Hard (enemies at 120%, smarter AI)
- Level 10: Boss (150% stats, special mechanics)
- Smooth scaling between tiers
```

## Economy Balance
```
Create Balance/EconomyConfig.cs with:
- Gold earned per enemy: baseHP * difficulty multiplier
- Item costs scale with power level
- Healing costs increase each use per battle
- Ensure player can afford upgrades without grinding
- Config loaded from JSON for easy tweaking
```

## Puzzle Difficulty Scaling
```
In Levels/LevelManager.cs, implement difficulty curve:
- Levels 1-3: 3x3 grid, 3-4 random moves
- Levels 4-6: 4x4 grid, 5-7 random moves
- Levels 7-9: 5x5 grid, 8-12 random moves
- Level 10+: 6x6 grid, 12+ random moves
- Par moves = random moves * 1.5
```
