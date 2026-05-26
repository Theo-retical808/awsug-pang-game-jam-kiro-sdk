# UI Redesign Prompts

## Custom Theme
```
Create UI/ThemeManager.cs with:
- Theme class: BackgroundColor, AccentColor, TextColor, FontFamily
- Predefined themes: Dark, Light, Retro, Neon
- ApplyTheme(Form form) method that updates all controls
- Save theme preference
```

## Animated Menu
```
In Forms/TitleForm.cs, add animations:
- Buttons fade in one by one on load (use Timer)
- Title text has a subtle pulse effect
- Background color slowly shifts between two colors
- Hover effect on buttons (color change)
```

## Health Bar Component
```
Create UI/HealthBar.cs as a custom Panel:
- Draws a colored bar (green > yellow > red based on %)
- Smooth animation when HP changes (lerp over 500ms)
- Shows "HP: current/max" text overlay
- Configurable size and colors
```

## Minimap
```
Create UI/Minimap.cs as a custom Panel:
- Small overview of the full grid (for tactical RPG)
- Color-coded dots for units (blue=player, red=enemy)
- Highlights current unit
- Fixed size 150x120 in corner
```

## Notification Toast
```
Create UI/ToastNotification.cs:
- Shows temporary message at top of screen
- Auto-fades after 2 seconds
- Queue multiple messages
- Configurable colors for info/success/warning/error
```
