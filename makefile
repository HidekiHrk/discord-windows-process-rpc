start:
	dotnet run

build:
	dotnet build

build-release:
	dotnet build -c release

build-winx86:
	dotnet build -c release -r win-x86
