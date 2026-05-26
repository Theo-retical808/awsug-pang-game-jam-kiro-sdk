# KIRO IDE Guide

## What is KIRO IDE?

KIRO is an AI-powered development environment. It helps you write code faster by understanding your project and generating code based on your instructions.

## Getting Started with KIRO

1. Open your template folder in KIRO
2. Use the chat panel to ask AI for help
3. Reference files with `#File` or `#Folder`
4. AI can read, edit, and create files for you

## Best Practices for Game Jam

### Be Specific
Instead of: "Make the game better"
Say: "Add a health potion item that restores 20 HP when used in combat"

### Reference Files
Instead of: "Change the combat system"
Say: "In #Combat/CombatResolver.cs, add critical hit chance of 15%"

### Work in Small Steps
1. Ask for one feature at a time
2. Test it works
3. Move to the next feature

### Use the Modular Architecture
Each system is in its own file. Tell AI exactly which file to edit:
- "Edit Units/Unit.cs to add a Speed stat"
- "Create a new file Abilities/ShieldAbility.cs"
- "Modify Forms/BattleForm.cs to show ability buttons"

## Efficient Prompting Patterns

### Adding a Feature
```
Add [feature] to [file/system].
It should [behavior].
Keep it in a separate file if it's a new system.
```

### Modifying Existing Code
```
In [filename], change [specific thing] to [new behavior].
Don't modify other files.
```

### Generating Content
```
Generate [number] [items] as JSON matching the format in [existing file].
```

### Fixing Issues
```
[File] has a bug: [description of what's wrong].
The expected behavior is [what should happen].
```

## Tips for Saving AI Credits

- Read the code yourself before asking AI to change it
- Be precise about what you want
- Don't ask AI to explain code you can read
- Batch related changes into one prompt when possible
- Use file references so AI doesn't need to search
