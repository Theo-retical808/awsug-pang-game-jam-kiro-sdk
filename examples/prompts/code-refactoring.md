# Code Refactoring Prompts

## Extract Interface
```
Create an interface IRenderable in Core/:
- void Render(Graphics g, Rectangle bounds)
- Apply it to GridPanel, SceneRenderer, PuzzlePanel
- This allows swapping renderers without changing game logic
```

## Add Events
```
In [Manager].cs, add events for key actions:
- OnActionStarted, OnActionCompleted
- Other systems can subscribe without coupling
- Use the EventBus pattern from shared/Core/
```

## Split Large File
```
[FileName].cs is getting large. Split it:
- Extract [SubSystem] into its own file
- Keep the same public methods
- Use internal access for shared state
- Update references in other files
```

## Add Configuration
```
Extract magic numbers from [FileName].cs into config:
- Create a [System]Config.cs with constants
- Or load from Assets/config.json
- Makes balancing easier without code changes
```

## Improve Error Handling
```
In [FileName].cs, add defensive checks:
- Null checks on collections before iterating
- Bounds checking on grid access
- Try-catch on file I/O operations
- Graceful fallbacks instead of crashes
```

## Add Logging
```
In [FileName].cs, add debug logging:
- Log key state changes (turn start, unit death, level complete)
- Use shared/Utilities/Logger.cs
- Set to LogLevel.Info for release
- Helps debug issues without stepping through code
```
