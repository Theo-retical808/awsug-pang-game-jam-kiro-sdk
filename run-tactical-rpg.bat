@echo off
title GAME CLOUD - Tactical RPG

:: Ensure user-local dotnet is on PATH
if exist "%LOCALAPPDATA%\dotnet\dotnet.exe" set "PATH=%LOCALAPPDATA%\dotnet;%PATH%"

echo Starting Tactical RPG...
pushd templates\tactical-rpg
dotnet run
popd
pause
