# Progression System Prompts

## Experience & Leveling
```
Create Progression/LevelingSystem.cs with:
- XP gained from defeating enemies (enemy HP * 2)
- Level up at thresholds: 100, 250, 500, 800, 1200...
- Each level: +2 HP, +1 ATK, +1 DEF
- Show level up notification
- Save XP and level with SaveManager
```

## Skill Tree
```
Create Progression/SkillTree.cs with:
- SkillNode class: name, description, cost, prerequisites
- Three branches: Offense, Defense, Utility
- Spend skill points (1 per level) to unlock nodes
- Unlocked skills grant passive bonuses or new abilities
```

## Equipment System
```
Create Items/Equipment.cs with:
- Slots: Weapon, Armor, Accessory
- Equipment modifies unit stats (+ATK, +DEF, etc.)
- Equip/Unequip methods on Unit
- Equipment data loaded from JSON
```

## Unlock System
```
Create Progression/UnlockManager.cs with:
- Track completed levels/achievements
- Unlock new unit types after milestones
- Unlock new puzzle types after completing sets
- Unlock cosmetic themes
- Persist unlocks in save data
```

## Difficulty Scaling
```
Create Progression/DifficultyScaler.cs with:
- Scale enemy stats based on player progress
- Formula: baseStat * (1 + 0.1 * levelDifference)
- Cap scaling at 2x base stats
- Optional: player can choose difficulty preset
```
