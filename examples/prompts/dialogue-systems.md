# Dialogue System Prompts

## Relationship System
```
Create Characters/RelationshipManager.cs with:
- Track affinity points per character (0-100)
- Increase/decrease based on choices
- Unlock special dialogue at thresholds (25, 50, 75, 100)
- Save relationship data with SaveManager
```

## Emotion System
```
Create Characters/EmotionSystem.cs with:
- Character moods: Happy, Sad, Angry, Neutral, Surprised
- Mood changes based on dialogue choices
- Mood affects available dialogue options
- Display mood indicator next to character name
```

## Dialogue Conditions
```
In Dialogue/DialogueManager.cs, add conditional lines:
- Add "condition" field to DialogueLine
- Conditions: hasItem, relationshipAbove, previousChoice
- Skip lines where condition is not met
- Example: only show line if relationship > 50
```

## Voice/Sound Cues
```
Create Dialogue/SoundCues.cs with:
- Map character names to beep patterns (frequency, duration)
- Play beep pattern during typewriter effect
- Different pitch per character
- Use Console.Beep() for simple implementation
```

## Narrative Flags
```
Create Dialogue/StoryFlags.cs with:
- Static dictionary of bool flags
- Set flags from dialogue choices
- Check flags in dialogue conditions
- Persist flags in save data
- Example: "has_met_wizard", "chose_dark_path"
```
