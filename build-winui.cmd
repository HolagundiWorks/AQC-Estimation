@echo off
REM Build AQC Estimation WinUI shell with VS 2022 MSBuild (dotnet CLI may lack Appx Pri tasks).
set MSB="%ProgramFiles%\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
if not exist %MSB% set MSB="%ProgramFiles(x86)%\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe"
%MSB% "%~dp0src\AQC-Estimation.csproj" /p:Configuration=Release /p:Platform=x64 /restore /v:m
