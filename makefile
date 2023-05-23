start:
	dotnet run

build:
	dotnet build

build-release:
	dotnet build -c Release

build-winx64:
	dotnet build -c Release --sc -r win-x64
	
build-winx86:
	dotnet build -c Release --sc -r win-x86
