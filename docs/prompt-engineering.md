# Prompt Engineering Guide

## Core Principle

Every AI credit counts. Write prompts that get results in ONE interaction.

## The SCRF Framework

**S**pecific — Name exact files and systems
**C**oncise — No unnecessary words
**R**esult-focused — Describe the end state
**F**ile-aware — Reference the architecture

## Good vs Bad Prompts

### Bad (wastes credits)
> "Can you help me make the combat more interesting?"

### Good (one-shot result)
> "In Combat/CombatResolver.cs, add a critical hit system: 15% chance to deal 2x damage. Show 'CRITICAL!' text in the InfoPanel when it happens."

## Prompt Templates

### New Feature
```
Create [filename] in [folder/].
It should:
- [requirement 1]
- [requirement 2]
- [requirement 3]
Use the same patterns as [existing similar file].
```

### Modify Existing
```
In [filename], make these changes:
1. [change 1]
2. [change 2]
Keep the existing API unchanged.
```

### Generate Data
```
Create [filename].json in Assets/ with [number] entries.
Format: { "field1": "type", "field2": "type" }
Theme: [description]
```

### UI Change
```
In Forms/[FormName].cs, add [component].
Style: dark background, Consolas font, [color] accent.
Position: [location description].
```

### Bug Fix
```
Bug in [filename]: [what happens]
Expected: [what should happen]
The issue is likely in [method/area].
```

## Multi-Step Features

For complex features, break into steps:

1. "Create the data model in [folder]/[Name]Data.cs"
2. "Create the manager in [folder]/[Name]Manager.cs"
3. "Wire it into [Form].cs with a button"

Each step = 1 credit. Total = 3 credits for a complete feature.

## Credit-Saving Tips

1. Never ask "what does this code do?" — read it yourself
2. Never ask for explanations — ask for implementations
3. Combine related small changes into one prompt
4. Always specify the file path
5. Describe the end result, not the process
6. Use existing patterns: "like CombatResolver but for healing"
