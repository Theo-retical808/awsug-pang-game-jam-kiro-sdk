@echo off
title GAME CLOUD - Visual Novel

:: Ensure user-local dotnet is on PATH
if exist "%LOCALAPPDATA%\dotnet\dotnet.exe" set "PATH=%LOCALAPPDATA%\dotnet;%PATH%"

echo Starting Visual Novel...
pushd templates\visual-novel
dotnet run
popd
pause
