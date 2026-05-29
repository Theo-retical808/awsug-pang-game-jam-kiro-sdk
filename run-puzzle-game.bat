@echo off
title GAME CLOUD - Puzzle Game

:: Ensure user-local dotnet is on PATH
if exist "%LOCALAPPDATA%\dotnet\dotnet.exe" set "PATH=%LOCALAPPDATA%\dotnet;%PATH%"

echo Starting Puzzle Game...
pushd templates\puzzle-game
dotnet run
popd
pause
