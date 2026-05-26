# Puzzle Game Template

A lightweight puzzle game framework using WinForms.

## Features Included
- Level system with progression
- Move counter
- Undo system
- Puzzle state tracking
- Modular puzzle base class
- Sample puzzle (Lights Out)
- Score system

## How to Run
```bash
dotnet run
```

## Structure
```
Forms/       - WinForms windows (GameForm, StatusPanel)
Puzzles/     - Puzzle logic (base class, implementations, renderer)
Levels/      - Level management and data
Mechanics/   - Game mechanics (moves, scoring)
Assets/      - Game data files
Saves/       - Runtime save files
```

## Customization Ideas
- Invent a completely new puzzle mechanic
- Add procedural puzzle generation
- Create a Sokoban-style push puzzle
- Add a match-3 puzzle type
- Implement a sliding tile puzzle
- Add time-based challenges
- Create a level editor
- Add achievements and unlockables
- Implement daily challenges

## AI Prompt Examples
- "Create a new puzzle type where you rotate tiles to connect paths"
- "Add procedural level generation that ensures solvability"
- "Implement a star rating system based on move count"
- "Create a Sokoban puzzle type with box pushing mechanics"
- "Add animated transitions when cells change state"
