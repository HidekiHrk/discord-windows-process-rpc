start:
	dotnet run

build:
	dotnet build

build-release:
	dotnet build -c Release

build-winx86:
	dotnet build -c Release -r win-x86
