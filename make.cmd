@echo off
dotnet clean
dotnet restore
dotnet publish -c Release