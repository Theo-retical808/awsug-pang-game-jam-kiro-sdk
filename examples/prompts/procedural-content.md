# Procedural Content Prompts

## Random Map Generation
```
Create Generation/MapGenerator.cs with:
- Generate grid maps with random terrain
- Place obstacles (20-30% of tiles)
- Ensure path exists between player start and enemy positions
- Difficulty parameter affects obstacle density
- Use seed for reproducible maps
```

## Random Enemy Encounters
```
Create Generation/EncounterGenerator.cs with:
- Generate enemy groups based on difficulty level
- Budget system: harder enemies cost more points
- Ensure variety (don't repeat same enemy type)
- Scale count: easy=2-3, medium=3-5, hard=4-6 enemies
```

## Dialogue Generator
```
Create Generation/DialogueGenerator.cs with:
- Templates for common dialogue patterns
- Fill-in-the-blank system with word lists
- Generate NPC greetings, hints, and flavor text
- Randomize from pools of phrases
```

## Loot Tables
```
Create Generation/LootTable.cs with:
- Weighted random item drops
- Rarity tiers: Common(60%), Uncommon(25%), Rare(12%), Epic(3%)
- Drop table per enemy type
- Guaranteed drops for bosses
```

## Procedural Puzzle Levels
```
Create Generation/PuzzleGenerator.cs with:
- Generate solvable puzzles of given difficulty
- Start from solved state, apply random valid moves
- More moves = harder puzzle
- Verify solvability before returning
- Track minimum solution length
```
