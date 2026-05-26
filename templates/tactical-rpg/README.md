# Tactical RPG Template

A lightweight tactical RPG framework using WinForms.

## Features Included
- Grid-based movement
- Turn-based combat
- Modular unit system
- Basic enemy AI
- HP and damage system
- Win/lose conditions
- Ability framework

## How to Run
```bash
dotnet run
```

## Structure
```
Forms/       - WinForms windows (BattleForm, InfoPanel)
Grid/        - Grid system (manager, tiles, renderer)
Units/       - Unit definitions and factory
Combat/      - Turn management and damage resolution
Abilities/   - Ability system and database
AI/          - Enemy AI behavior
Assets/      - Game data files
Saves/       - Runtime save files
```

## Customization Ideas
- Add new unit classes (healer, assassin, tank)
- Create terrain effects (water slows, forest gives defense)
- Implement experience and leveling
- Add equipment and items
- Create boss encounters with special mechanics
- Add status effects (poison, stun, buff)
- Implement fog of war
- Create a campaign with multiple battles
- Add procedural map generation

## AI Prompt Examples
- "Add a leveling system where units gain XP after defeating enemies"
- "Create terrain types that affect movement and combat"
- "Add a new unit class called Assassin with backstab ability"
- "Implement fog of war that reveals tiles as units move"
- "Create a boss enemy with multiple phases"
