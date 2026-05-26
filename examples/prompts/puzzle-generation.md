# Puzzle Generation Prompts

## Sliding Tile Puzzle
```
Create Puzzles/SlidingPuzzle.cs extending PuzzleState:
- NxN grid with numbered tiles and one empty space
- Click adjacent tile to slide it into empty space
- Solved when tiles are in order (1,2,3...N)
- Generate by making random valid moves from solved state
```

## Color Matching Puzzle
```
Create Puzzles/ColorMatchPuzzle.cs extending PuzzleState:
- Grid of colored cells (4 colors)
- Click to cycle a cell's color
- Solved when all cells in a row match
- Use GetCellColor to return the actual color
```

## Path Connection Puzzle
```
Create Puzzles/PathPuzzle.cs extending PuzzleState:
- Grid with pipe/path segments
- Click to rotate segments 90 degrees
- Solved when path connects start to end
- Cell values represent rotation (0,1,2,3)
```

## Procedural Generation
```
In Levels/LevelGenerator.cs, create:
- GenerateLevel(difficulty) method
- Difficulty affects grid size and complexity
- Ensure generated puzzles are always solvable
- Return a configured PuzzleState
```

## Memory Puzzle
```
Create Puzzles/MemoryPuzzle.cs extending PuzzleState:
- Grid of face-down cards (pairs)
- Click to reveal, match pairs
- Track revealed state and matched state
- Solved when all pairs found
- Use timer to hide unmatched after 1 second
```
