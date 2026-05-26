@echo off
title GAME CLOUD - Environment Setup
color 0A

echo ============================================
echo        GAME CLOUD - Quick Setup
echo ============================================
echo.

:: ──────────────────────────────────────────────
:: STEP 1: Check if .NET 8 SDK is installed
:: ──────────────────────────────────────────────
echo [1/5] Checking for .NET SDK...

dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo [!] .NET SDK not found. Installing...
    goto :install_dotnet
)

:: Check if it's .NET 8+
for /f "tokens=1 delims=." %%m in ('dotnet --version') do set DOTNET_MAJOR=%%m
if %DOTNET_MAJOR% LSS 8 (
    echo [!] .NET %DOTNET_MAJOR% found but .NET 8 is required. Installing...
    goto :install_dotnet
)

for /f "tokens=*" %%v in ('dotnet --version') do set DOTNET_VER=%%v
echo [OK] .NET SDK %DOTNET_VER% detected.
goto :dotnet_ready

:install_dotnet
echo.
echo      Downloading .NET 8 SDK installer...
echo.

:: Download the official dotnet-install script
powershell -NoProfile -ExecutionPolicy Bypass -Command ^
    "try { Invoke-WebRequest -Uri 'https://dot.net/v1/dotnet-install.ps1' -OutFile '%TEMP%\dotnet-install.ps1' -UseBasicParsing } catch { exit 1 }"

if %errorlevel% neq 0 (
    color 0C
    echo [ERROR] Failed to download .NET installer.
    echo.
    echo Please install .NET 8 SDK manually from:
    echo https://dotnet.microsoft.com/download/dotnet/8.0
    echo.
    pause
    exit /b 1
)

echo      Running .NET 8 SDK installer (this may take a few minutes)...
echo.

powershell -NoProfile -ExecutionPolicy Bypass -Command ^
    "& '%TEMP%\dotnet-install.ps1' -Channel 8.0 -InstallDir '%LOCALAPPDATA%\dotnet'"

if %errorlevel% neq 0 (
    color 0C
    echo [ERROR] .NET 8 installation failed.
    echo.
    echo Please install manually from:
    echo https://dotnet.microsoft.com/download/dotnet/8.0
    echo.
    pause
    exit /b 1
)

:: Add to PATH for this session
set "PATH=%LOCALAPPDATA%\dotnet;%PATH%"

:: Verify installation
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    color 0C
    echo [ERROR] .NET installed but not accessible. Please restart your terminal.
    pause
    exit /b 1
)

for /f "tokens=*" %%v in ('dotnet --version') do set DOTNET_VER=%%v
echo [OK] .NET SDK %DOTNET_VER% installed successfully.
echo.
echo [NOTE] You may need to restart your terminal for PATH changes
echo        to take effect globally. This session is already configured.
echo.

:dotnet_ready

:: ──────────────────────────────────────────────
:: STEP 2: Check if templates are already restored
:: ──────────────────────────────────────────────
echo [2/5] Checking project state...

set NEEDS_RESTORE=0

if not exist "templates\visual-novel\obj\project.assets.json" set NEEDS_RESTORE=1
if not exist "templates\tactical-rpg\obj\project.assets.json" set NEEDS_RESTORE=1
if not exist "templates\puzzle-game\obj\project.assets.json" set NEEDS_RESTORE=1

if %NEEDS_RESTORE%==0 (
    echo [OK] All templates already restored. Skipping restore.
    goto :check_builds
)

echo [!] One or more templates need restoring...
echo.

:: ──────────────────────────────────────────────
:: STEP 3: Restore templates
:: ──────────────────────────────────────────────
echo [3/5] Restoring templates...

echo      - Visual Novel...
pushd templates\visual-novel
dotnet restore --quiet
if %errorlevel% neq 0 (
    color 0C
    echo [ERROR] Failed to restore Visual Novel.
    popd
    pause
    exit /b 1
)
popd

echo      - Tactical RPG...
pushd templates\tactical-rpg
dotnet restore --quiet
if %errorlevel% neq 0 (
    color 0C
    echo [ERROR] Failed to restore Tactical RPG.
    popd
    pause
    exit /b 1
)
popd

echo      - Puzzle Game...
pushd templates\puzzle-game
dotnet restore --quiet
if %errorlevel% neq 0 (
    color 0C
    echo [ERROR] Failed to restore Puzzle Game.
    popd
    pause
    exit /b 1
)
popd

echo [OK] All templates restored.
echo.

:: ──────────────────────────────────────────────
:: STEP 4: Verify builds
:: ──────────────────────────────────────────────
:check_builds
echo [4/5] Verifying builds...

set BUILD_OK=1

pushd templates\visual-novel
dotnet build --no-restore --quiet >nul 2>&1
if %errorlevel% neq 0 (
    echo      [WARN] Visual Novel has build issues.
    set BUILD_OK=0
) else (
    echo      [OK] Visual Novel builds.
)
popd

pushd templates\tactical-rpg
dotnet build --no-restore --quiet >nul 2>&1
if %errorlevel% neq 0 (
    echo      [WARN] Tactical RPG has build issues.
    set BUILD_OK=0
) else (
    echo      [OK] Tactical RPG builds.
)
popd

pushd templates\puzzle-game
dotnet build --no-restore --quiet >nul 2>&1
if %errorlevel% neq 0 (
    echo      [WARN] Puzzle Game has build issues.
    set BUILD_OK=0
) else (
    echo      [OK] Puzzle Game builds.
)
popd

echo.

:: ──────────────────────────────────────────────
:: STEP 5: Create Saves directories
:: ──────────────────────────────────────────────
echo [5/5] Ensuring runtime directories exist...

if not exist "templates\visual-novel\Saves" mkdir "templates\visual-novel\Saves"
if not exist "templates\tactical-rpg\Saves" mkdir "templates\tactical-rpg\Saves"
if not exist "templates\puzzle-game\Saves" mkdir "templates\puzzle-game\Saves"

echo [OK] Runtime directories ready.
echo.

:: ──────────────────────────────────────────────
:: DONE
:: ──────────────────────────────────────────────
if %BUILD_OK%==1 (
    color 0A
    echo ============================================
    echo      Setup Complete - All Systems Go!
    echo ============================================
) else (
    color 0E
    echo ============================================
    echo    Setup Complete (with warnings above)
    echo ============================================
)

echo.
echo To run a template, double-click one of these:
echo.
echo   run-visual-novel.bat
echo   run-tactical-rpg.bat
echo   run-puzzle-game.bat
echo.
echo Or from terminal:
echo   cd templates\visual-novel   ^& dotnet run
echo   cd templates\tactical-rpg   ^& dotnet run
echo   cd templates\puzzle-game    ^& dotnet run
echo.
echo Happy jamming! Good luck with GAME CLOUD!
echo ============================================
pause
