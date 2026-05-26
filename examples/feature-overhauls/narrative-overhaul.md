# Narrative System Overhaul Example

## Goal
Transform the placeholder visual novel into a branching mystery story.

## Step-by-Step (6-8 credits)

### Credit 1: Create story flags system
```
Create Dialogue/StoryFlags.cs with a static Dictionary<string, bool>.
Add SetFlag, GetFlag, and HasFlag methods.
Integrate with SaveManager for persistence.
```

### Credit 2: Add conditional dialogue
```
Add "condition" field to DialogueLine.
In DialogueManager.Advance(), skip lines where condition is not met.
Conditions check StoryFlags (e.g., "has_clue_1" must be true).
```

### Credit 3: Generate mystery story script
```
Create Assets/Scripts/chapter1.json with:
- 15 dialogue lines introducing a mystery
- 2 investigation choices that set different flags
- Clue discovery that sets "has_clue_1" flag
- Branch based on which clues were found
```

### Credit 4: Add character relationships
```
Create Characters/RelationshipManager.cs.
Track trust level (0-100) per character.
Choices affect trust. High trust unlocks secret dialogue.
```

### Credit 5: Create multiple endings
```
Create Assets/Scripts/ending_good.json and ending_bad.json.
Good ending requires: has_clue_1 AND has_clue_2 AND trust > 50.
Bad ending is the default if conditions aren't met.
Add ending selection logic to DialogueManager.
```

### Credit 6: Add investigation UI
```
Create Forms/InvestigationPanel.cs.
Show clickable hotspots on the scene.
Clicking reveals clues and sets story flags.
Integrate with SceneRenderer.
```

## Result
A complete mystery visual novel with meaningful choices, clue-finding, and multiple endings.
