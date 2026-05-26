# Save System Prompts

## Multiple Save Slots
```
Create Saves/SaveSlotUI.cs with:
- Display 3 save slots with timestamp and progress info
- Click to load, long-press to delete
- Show "Empty Slot" for unused slots
- Auto-save to most recent slot
```

## Auto-Save
```
Create Saves/AutoSaveManager.cs with:
- Auto-save every N turns/actions
- Keep last 3 auto-saves (rotating)
- Save on level complete
- Save on application close
- Don't save during active combat/puzzle
```

## Save Data Structure
```
Create Saves/GameSaveData.cs with:
- Player progress (level, XP, stats)
- Inventory contents
- Story flags / dialogue progress
- Current level/scene
- Timestamp
- Play time
Use System.Text.Json serialization.
```

## Cloud-Style Backup
```
Create Saves/BackupManager.cs with:
- Copy save files to a backup folder
- Keep last 5 backups with timestamps
- Restore from backup option
- Validate save file integrity (check JSON parse)
```
