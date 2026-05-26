# Submission Guide

## Before Submitting

### Checklist
- [ ] Game runs without errors (`dotnet run`)
- [ ] Game is playable from start to finish
- [ ] README.md updated with your game description
- [ ] No placeholder content remaining (or intentionally kept)
- [ ] Save system works (if applicable)
- [ ] No hardcoded file paths

### Clean Up
- Remove debug output (Console.WriteLine)
- Remove unused placeholder code
- Ensure Assets/ contains only needed files
- Test on a clean build: `dotnet clean && dotnet run`

## Submission Format

### Required Files
```
your-game/
├── [YourGame].sln
├── [YourGame].csproj
├── Program.cs
├── README.md          ← Describe your game!
├── [your source files]
└── Assets/
```

### README Requirements
Your README should include:
1. Game title and description
2. How to play (controls, objective)
3. What you built/changed from the template
4. Any special features or mechanics
5. Credits (if using external assets)

## How to Submit

1. Ensure your code is committed to Git
2. Push to your repository
3. Verify the repo is accessible
4. Submit the repository URL through the jam portal

## Common Issues

| Issue | Fix |
|-------|-----|
| Build fails on judge's machine | Remove absolute paths, test with `dotnet clean && dotnet build` |
| Missing assets | Ensure Assets/ files are committed to Git |
| Wrong .NET version | Keep `net8.0-windows` in .csproj |
| Game crashes on start | Test after a fresh `dotnet restore` |
