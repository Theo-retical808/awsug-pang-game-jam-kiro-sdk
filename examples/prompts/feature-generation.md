# Feature Generation Prompts

## Inventory System
```
Create Items/Inventory.cs with:
- List of items (name, description, quantity)
- AddItem, RemoveItem, HasItem methods
- Maximum capacity of 20 items
- Event when inventory changes
```

## Weather System
```
Create Systems/WeatherSystem.cs with:
- Weather states: Clear, Rain, Storm, Fog
- Random weather changes every 5 turns
- Weather affects gameplay (e.g., Rain reduces accuracy by 10%)
- Event when weather changes
```

## Achievement System
```
Create Systems/AchievementManager.cs with:
- Achievement class (id, name, description, isUnlocked)
- Check conditions and unlock achievements
- Save unlocked achievements to JSON
- Predefined achievements: "First Victory", "No Damage", "Speed Run"
```

## Day/Night Cycle
```
Create Systems/TimeSystem.cs with:
- Time states: Dawn, Day, Dusk, Night
- Advances each turn
- Affects background color in the renderer
- Some units get bonuses at night
```
