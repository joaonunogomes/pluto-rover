# dotnetcore-boilerplate-api

DotNetCoreBoilerplateApi - .NET Core REST API

# Before running
- Install .NET Core 3.1 - SDK and Runtime (https://dotnet.microsoft.com/download/dotnet-core/3.1)
- Install Docker
- Install Visual Studio Code or Visual Studio

# How to run
## With docker (no debug)
To run this application with docker, simply clone this repo, open a command line on project root folder and run `docker-compose -f "docker-compose.yml" up -d --build`

## With VS Code (open source - development and debugging)
To run with VS Code install the following extension on your VS Code:
- C#
- .NET Core Test Explorer
- Visual Studio Keymap
- Visual Studio IntelliCode
- NuGet Package Manager

After that, click on debug icon and then click on **Run**
An instance of the server should start running on `http://localhost:9199`