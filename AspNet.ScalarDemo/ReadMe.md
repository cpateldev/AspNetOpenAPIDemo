# ASP.NET Core Todo API with Scalar API Reference Demo

A minimal API demo project showcasing Todo management with OpenAPI and scalar API doc.

## Table of Contents
- [Platforms](#platforms)
- [Overview](#overview)
  - [Key Features](#key-features)
- [Getting Started](#getting-started)
- [NuGet Package Configuration](#nuget-package-configuration)
  - [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](#microsoftaspnetcorediagnosticsentityframeworkcore)
  - [Microsoft.AspNetCore.OpenApi](#microsoftaspnetcoreopenapi)
  - [Microsoft.EntityFrameworkCore.InMemory](#microsoftentityframeworkcoreinmemory)
  - [Scalar.AspNetCore](#scalaraspnetcore)
- [Database Configuration](#database-configuration)
- [API Endpoints](#api-endpoints)
- [Launch Settings](#launch-settings)
  - [Development Server](#development-server)
- [Project Structure](#project-structure)
- [Model Definitions](#model-definitions)
  - [Todo Model](#todo-model)
  - [TodoItemDTO Model](#todoitemdto-model)
- [Contributing](#contributing)
- [License](#license)

## Platforms

![Framework](https://img.shields.io/badge/Framework-.NET%209.0-purple?style=for-the-badge) 
![Platform](https://img.shields.io/badge/Platforms-Windows%20%7C%20Linux%20%7C%20mac%20OS-blue?style=for-the-badge)
![OpenAPI](https://img.shields.io/badge/OpenAPI-3.0.1-darkgreen?style=for-the-badge)

## Overview

This is a minimal API project built with ASP.NET Core 9.0 that demonstrates the implementation of a Todo API using scalar types. The project showcases modern .NET features and REST API development practices with strong type safety.

### Key Features

- Minimal API implementation
- OpenAPI 3.0.1 integration
- Entity Framework Core with In-Memory database
- CRUD operations for Todo items
- Strongly typed scalar parameters
- DTO pattern implementation

## Getting Started
1. Clone the repository:
  ```bash
  git clone https://github.com/your-repo/AspNet.ScalarDemo.git
  cd AspNet.ScalarDemo
  ```

2. Build the project:
  ```bash
  dotnet build
  ```

3. Run the application:
  ```bash
  dotnet run
  ```

4. Access the API:
  - Scalar API UI: `https://localhost:7096/scalar/v1` or `http://localhost:5072/scalar/v1`
  - API Base URL: 
    - HTTPS: `https://localhost:7096/todoitems`
    - HTTP: `http://localhost:5072/toitems`

## NuGet Package Configuration
The following NuGet packages are required for this project:

### Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
- Provides middleware for Entity Framework Core error pages
- Enables detailed database error information during development
```powershell
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 9.0.2
```

### Microsoft.AspNetCore.OpenApi
- Enables OpenAPI description for ASP.NET Core APIs
- Required for Swagger documentation generation
```powershell
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.2
```

### Microsoft.EntityFrameworkCore.InMemory
- Provides in-memory database provider for Entity Framework Core
- Useful for testing and development scenarios
```powershell
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 9.0.2
```

### Scalar.AspNetCore
- Adds Scalar API Reference UI for modern API documentation
- Provides interactive API documentation and testing interface
```powershell
dotnet add package Scalar.AspNetCore --version 0.3.0
```
```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="9.0.2" />
  <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.2" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.2" />
  <PackageReference Include="Scalar.AspNetCore" Version="0.3.0" />
</ItemGroup>
```
## Database Configuration

The project uses Entity Framework Core's In-Memory database provider for demonstration purposes. The database is pre-populated with sample Todo items on application startup.

## API Endpoints

| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| GET | `/todoitems` | Get all todo items | 200 |
| GET | `/todoitems/complete` | Get completed todo items | 200 |
| GET | `/todoitems/{id}` | Get a specific todo item | 200, 404 |
| POST | `/todoitems` | Create a new todo item | 201 |
| PATCH | `/todoitems/{id}` | Update todo item name | 204, 404 |
| PUT | `/todoitems/{id}` | Update entire todo item | 204, 404 |
| POST | `/todoitems/batch` | Create multiple todo items | 200 |
| DELETE | `/todoitems/{id}` | Delete a todo item | 200, 404 |

## Launch Settings

The application can be run using the following endpoints:

### Development Server
- HTTP: `http://localhost:5072`
- HTTPS: `https://localhost:7096`

The environment is configured via `launchSettings.json`:

```json
{
  "profiles": {
    "http": {
      "applicationUrl": "http://localhost:5072",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "applicationUrl": "https://localhost:7096;http://localhost:5072",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## Project Structure

📁 AspNet.ScalarDemo/
- 📄 `Program.cs` - Main application entry point and API configuration
- 📄 `Properties/`
  - 📄 `launchSettings.json` - Launch profiles configuration
- 📄 `Todo.cs` - Todo entity model with Tag support
- 📄 `TodoItemDTO.cs` - Data Transfer Object for Todo items
- 📄 `Tag.cs` - Tag model for todo items
- 📄 `TodoDb.cs` - Database context and configurations
- 📄 `appsettings.json` - Application configuration
- 📄 `appsettings.Development.json` - Development environment settings
- 📄 `AspNet.ScalarDemo.csproj` - Project file with package references
- 📄 `ReadMe.md` - Project documentation

## Model Definitions

### Todo Model
```csharp
public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public Tag Tag { get; set; } = new();
}
```

### TodoItemDTO Model
```csharp
public class TodoItemDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
```

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.


[Go to TOC](#table-of-contents)
