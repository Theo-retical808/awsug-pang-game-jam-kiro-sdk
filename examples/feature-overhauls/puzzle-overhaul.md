# Puzzle Game Overhaul Example

## Goal
Transform the single puzzle type into a multi-mechanic puzzle adventure.

## Step-by-Step (5-7 credits)

### Credit 1: Create a new puzzle type
```
Create Puzzles/SlidingPuzzle.cs extending PuzzleState:
- 4x4 grid with numbered tiles 1-15 and one empty space
- Click adjacent tile to slide into empty space
- Solved when numbers are in order
- Generate by shuffling from solved state
```

### Credit 2: Add level select screen
```
Create Forms/LevelSelectForm.cs:
- Grid of level buttons (numbered)
- Show star rating on completed levels
- Locked levels shown as gray
- Complete a level to unlock the next
```

### Credit 3: Add scoring and stars
```
In Mechanics/ScoreSystem.cs, implement star ratings:
- 3 stars: complete in par moves or fewer
- 2 stars: complete in par * 1.5 moves
- 1 star: complete at all
- Show stars on level complete popup
- Track best score per level
```

### Credit 4: Add timer mode
```
Create Mechanics/TimerMode.cs:
- Optional countdown timer per level
- Bonus points for time remaining
- Timer displayed in StatusPanel
- Configurable per level (some levels are untimed)
```

### Credit 5: Procedural generation
```
Create Levels/PuzzleGenerator.cs:
- Generate solvable puzzles based on difficulty
- Difficulty 1-3: small grid, few moves
- Difficulty 4-7: medium grid, more moves
- Difficulty 8-10: large grid, many moves
- Add "Random Challenge" button that generates a new puzzle
```

## Result
A puzzle game with multiple mechanics, progression, scoring, and infinite replayability.
