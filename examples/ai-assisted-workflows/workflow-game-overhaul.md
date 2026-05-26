# AI Workflow: Game Overhaul Strategy

## When to Overhaul vs Extend

**Extend** (1-2 credits): Adding something new without changing existing systems
- New unit type, new puzzle, new dialogue script

**Overhaul** (3-5 credits): Fundamentally changing how a system works
- Redesigning combat, changing puzzle mechanics, new UI layout

## Overhaul Strategy

### Phase 1: Core Change (1-2 credits)
Change the fundamental mechanic first. Everything else builds on this.

Example: "Change combat from individual turns to team-based phases"
```
Rewrite TurnManager.cs to use phases:
- Player Phase: all player units can act
- Enemy Phase: all enemies act
- Remove individual unit turn order
- Add "actions remaining" counter per phase
```

### Phase 2: Adapt Existing Systems (1-2 credits)
Update systems that depend on the core change.

```
Update BattleForm.cs:
- Show "Actions: X remaining" instead of active unit
- Allow clicking any player unit during player phase
- End phase button instead of end turn
```

### Phase 3: Add New Content (1-2 credits)
Now that the system works differently, add content that leverages it.

```
Add team synergy bonuses:
- Adjacent allies give +1 DEF
- Same-element allies give +10% damage
- Show synergy indicators on grid
```

## Budget Planning

| Overhaul Type | Estimated Credits |
|---------------|-------------------|
| Combat redesign | 4-6 |
| New puzzle mechanic | 3-4 |
| UI overhaul | 2-3 |
| Story rewrite | 3-5 |
| Progression system | 3-4 |

## Golden Rule
Always change the core mechanic FIRST, then adapt the UI and content.
Never start with UI changes for an overhaul.
