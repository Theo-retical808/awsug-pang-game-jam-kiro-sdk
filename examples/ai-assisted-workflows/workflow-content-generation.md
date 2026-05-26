# AI Workflow: Content Generation

## Best ROI: Generate Data, Not Code

Generating JSON data files gives you the most content per credit.

## Dialogue Content (Visual Novel)

### Generate a full story chapter (1 credit)
```
Create Assets/Scripts/chapter2.json with 20 dialogue lines:
- Setting: a mysterious library at night
- Characters: Detective (player), Librarian, Ghost
- Include 3 branching choices
- End with a cliffhanger
- Use the same JSON format as intro.json
```

### Generate character profiles (1 credit)
```
Create Assets/characters.json with 5 characters:
Format: { "id": "", "name": "", "personality": "", "role": "", "secretMotivation": "" }
Theme: noir mystery in a small town
```

## Unit/Enemy Data (Tactical RPG)

### Generate enemy roster (1 credit)
```
Create Assets/enemies.json with 12 enemy types:
Format: { "name": "", "hp": 0, "attack": 0, "defense": 0, "moveRange": 0, "attackRange": 0, "element": "" }
Include: 4 basic, 4 elite, 4 boss enemies
Scale stats appropriately (basic: 10-20 HP, boss: 50-100 HP)
```

### Generate ability list (1 credit)
```
Create Assets/abilities.json with 15 abilities:
Format: { "name": "", "power": 0, "range": 0, "cooldown": 0, "element": "", "description": "" }
Mix of: 5 attack, 4 support, 3 debuff, 3 area-of-effect
```

## Level Data (Puzzle Game)

### Generate level configurations (1 credit)
```
Create Assets/levels.json with 10 level configs:
Format: { "level": 0, "gridSize": 0, "difficulty": 0, "parMoves": 0, "name": "" }
Smooth difficulty curve from easy (3x3, par 5) to hard (6x6, par 20)
```

## Tips
- Always reference the existing JSON format
- Specify exact count of items needed
- Give a theme or constraint for variety
- One generation prompt = lots of game content
