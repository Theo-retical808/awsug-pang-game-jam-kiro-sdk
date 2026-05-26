# 📋 INSTRUCTIONS

Complete setup and getting-started guide for the AWSUG PANG Game Jam.

---

## 🚀 Step 1 — Clone the Repository

Open a terminal and run:

```bash
git clone https://github.com/Theo-retical808/awsug-pang-game-jam-kiro-sdk.git
cd awsug-pang-game-jam-kiro-sdk
```

---

## 🛠 Step 2 — Run the Setup Script

Double-click **`setup.bat`** in the root folder (or run it from terminal).

This script will automatically:
1. Check if .NET 8 SDK is installed — if not, it installs it for you
2. Restore all template dependencies
3. Verify everything builds correctly
4. Create necessary runtime folders

If setup completes with **"All Systems Go!"**, you're ready.

> 💡 If you already have .NET 8 and have run setup before, the script detects this and skips unnecessary steps.

---

## 🎯 Step 3 — Choose Your Template

You must pick **ONE** template to work with. Here are your options:

| Template | Folder | Description |
|----------|--------|-------------|
| **Visual Novel** | `templates/visual-novel/` | Dialogue, branching choices, scenes, typewriter effect |
| **Tactical RPG** | `templates/tactical-rpg/` | Grid combat, turn-based, units, enemy AI |
| **Puzzle Game** | `templates/puzzle-game/` | Puzzle mechanics, levels, scoring, undo system |

To test a template before choosing, double-click one of the run scripts:
- `run-visual-novel.bat`
- `run-tactical-rpg.bat`
- `run-puzzle-game.bat`

---

## 🗑️ Step 4 — Delete the Templates You Did NOT Choose

> ⚠️ **This is required.** You must remove the templates you are NOT using.

Once you've decided on your template, **delete the other two folders**.

### If you chose Visual Novel:
```bash
rmdir /s /q templates\tactical-rpg
rmdir /s /q templates\puzzle-game
```

### If you chose Tactical RPG:
```bash
rmdir /s /q templates\visual-novel
rmdir /s /q templates\puzzle-game
```

### If you chose Puzzle Game:
```bash
rmdir /s /q templates\visual-novel
rmdir /s /q templates\tactical-rpg
```

Or simply delete the folders manually in File Explorer.

**Why?** 
- Keeps your repository clean for submission
- Avoids confusion about which template is yours
- Reduces repo size
- Makes it clear to judges which game you built

---

## 💻 Step 5 — Open in Kiro IDE

1. Open **Kiro IDE**
2. Open the folder of your chosen template (e.g., `templates/visual-novel/`)
3. You're ready to start building!

---

## ▶️ Step 6 — Run Your Game

From your template folder:

```bash
dotnet run
```

Or use the corresponding `run-*.bat` file from the root.

---

## 🧠 Step 7 — Start Creating

Use Kiro IDE's AI chat to:
- Add new features
- Redesign gameplay
- Generate content (dialogue, levels, enemies)
- Overhaul systems
- Fix bugs

Check the `docs/` folder for guides:
- `docs/kiro-guide.md` — How to use Kiro effectively
- `docs/prompt-engineering.md` — Write prompts that save credits
- `docs/ai-credit-optimization.md` — Budget your 50 credits wisely

Check `examples/prompts/` for ready-to-use prompt templates.

---

## 📦 Step 8 — Submit Your Project

1. Commit your changes:
```bash
git add .
git commit -m "My game jam submission"
```

2. Push to your own repository (fork or new repo):
```bash
git remote set-url origin https://github.com/YOUR-USERNAME/YOUR-REPO-NAME.git
git push -u origin main
```

3. Submit your repository URL through the jam portal.

See `docs/submission-guide.md` for the full checklist.

---

## ❓ Troubleshooting

| Problem | Solution |
|---------|----------|
| `setup.bat` says .NET not found | Let it install automatically, or download from https://dotnet.microsoft.com/download/dotnet/8.0 |
| Build fails after setup | Run `dotnet restore` in your template folder |
| Game window doesn't appear | Make sure you're on Windows (WinForms requires it) |
| "Access denied" on setup | Right-click `setup.bat` → Run as Administrator |
| Deleted wrong template | Re-clone the repo and start over |

---

## 📁 Final Repository Structure (After Cleanup)

Your submitted repo should look like this (example for Tactical RPG):

```
awsug-pang-game-jam-kiro-sdk/
├── INSTRUCTIONS.md
├── README.md
├── setup.bat
├── run-tactical-rpg.bat
├── docs/
├── shared/
├── examples/
└── templates/
    └── tactical-rpg/      ← Only YOUR chosen template remains
        ├── TacticalRPG.sln
        ├── Program.cs
        ├── Forms/
        ├── Combat/
        ├── Grid/
        ├── Units/
        ├── Abilities/
        ├── AI/
        ├── Assets/
        └── Saves/
```

---

## 🎮 Good Luck!

Remember the philosophy:

> "The templates provide infrastructure. You use AI credits to creatively transform the experience."

Paint the canvas purple. Make it yours. Have fun!
