# Setup Guide

## Prerequisites

- Windows 10/11
- .NET 8 SDK

## Step 1: Install .NET 8

1. Go to https://dotnet.microsoft.com/download/dotnet/8.0
2. Download the SDK installer for Windows
3. Run the installer
4. Verify: open a terminal and run `dotnet --version`

## Step 2: Clone the Repository

```bash
git clone <your-repo-url>
cd game-cloud-dotnet-sdk
```

## Step 3: Choose a Template

Navigate to one of the templates:

```bash
cd templates/visual-novel
# OR
cd templates/tactical-rpg
# OR
cd templates/puzzle-game
```

## Step 4: Run the Template

```bash
dotnet run
```

The game window should appear. You're ready to start developing!

## Step 5: Open in KIRO IDE

1. Open KIRO IDE
2. Open the template folder you chose
3. Start using AI to customize your game

## Troubleshooting

| Problem | Solution |
|---------|----------|
| `dotnet` not found | Restart terminal after installing .NET |
| Build errors | Run `dotnet restore` first |
| Window doesn't appear | Ensure you're on Windows (WinForms requirement) |
| Missing SDK | Check `dotnet --list-sdks` for .NET 8 |

## Project Structure Tips

- Each template is self-contained — just run `dotnet run` in its folder
- The `shared/` folder has reusable utilities you can copy into your project
- Edit any file independently — the modular design means changes are isolated
