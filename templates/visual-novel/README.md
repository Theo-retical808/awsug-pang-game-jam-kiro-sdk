# Visual Novel Template

A lightweight visual novel framework using WinForms.

## Features Included
- Dialogue system with typewriter effect
- Branching choices
- Scene management
- Character system
- Modular JSON-based scripts

## How to Run
```bash
dotnet run
```

## Structure
```
Forms/        - WinForms windows (MainForm, TitleForm)
Dialogue/     - Dialogue system (manager, data, UI panels)
Scenes/       - Scene rendering and data
Characters/   - Character definitions
Assets/       - Game data (scripts, images)
Saves/        - Runtime save files
```

## Customization Ideas
- Write your own story in Assets/Scripts/
- Add character portraits and expressions
- Create multiple routes and endings
- Add a relationship/affinity system
- Implement an inventory or item system
- Add music and sound effects
- Create animated transitions between scenes
- Add a gallery/CG collection system
- Implement achievements

## AI Prompt Examples
- "Add a relationship points system that tracks affinity with each character"
- "Create a new character named Luna with 3 expressions"
- "Generate a mystery story script with 5 scenes and 2 endings"
- "Add background music support using System.Media"
