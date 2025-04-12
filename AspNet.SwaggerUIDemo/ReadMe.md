# ASP.NET Core Todo API with SwaggerUI Demo

A minimal API demo project showcasing Todo management with OpenAPI (Swagger) documentation using ASP.NET Core 9.0.

## Platforms

![Framework](https://img.shields.io/badge/Framework-.NET%209.0-purple?style=for-the-badge) 
![Platform](https://img.shields.io/badge/Platforms-Windows%20%7C%20Linux%20%7C%20mac%20OS-blue?style=for-the-badge)
![OpenAPI](https://img.shields.io/badge/OpenAPI-3.0.1-darkgreen?style=for-the-badge)

## Overview

This is a minimal API project built with ASP.NET Core 9.0 that demonstrates the implementation of a Todo API with SwaggerUI integration. The project showcases modern .NET features and REST API development practices.

### Key Features

- Minimal API implementation
- SwaggerUI integration for API documentation and testing
- Entity Framework Core with In-Memory database
- CRUD operations for Todo items
- Batch operations support
- DTO pattern implementation
- Tag-based categorization for Todo items

## NuGet Package Configuration

The project uses the following NuGet packages:

```xml
<PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="9.0.2" />
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.2" />
<PackageReference Include="Swashbuckle.AspNetCore.SwaggerUI" Version="7.2.0" />
```

To install these packages, run:

```bash
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Swashbuckle.AspNetCore.SwaggerUI
```

## Database Configuration

The project uses Entity Framework Core's In-Memory database provider for demonstration purposes. The database is pre-populated with sample Todo items on application startup.

### Pre-populated Data
- "Go to watch movie"
- "Get the dog for a walk" (Completed)
- "Buy 3 gallons of milk"
- "Call mom" (Completed)
- "Do the laundry"
- "Finish the book" (Completed)
- "Go to the gym"
- "Buy a new phone" (Completed)
- "Get the car fixed"
- "Go to the supermarket" (Completed)

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

### HTTP Profile
```json
{
  "applicationUrl": "http://localhost:5023",
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
}
```

### HTTPS Profile
```json
{
  "applicationUrl": "https://localhost:7096;http://localhost:5023",
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
}
```

## Project Structure

📁 AspNet.SwaggerUIDemo/
- 📄 `Program.cs` - Main application entry point and API routes
- 📄 `Todo.cs` - Todo entity model with Tag support
- 📄 `TodoItemDTO.cs` - Data Transfer Object for Todo items
- 📄 `TodoDb.cs` - Database context configuration
- 📄 `appsettings.json` - Application configuration
- 📄 `appsettings.Development.json` - Development configuration
- 📄 `Properties/launchSettings.json` - Launch profiles configuration

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

## Getting Started

1. Clone the repository
2. Ensure .NET 9.0 SDK is installed
3. Run the following commands:
```bash
cd AspNet.SwaggerUIDemo
dotnet restore
dotnet build
dotnet run
```
4. Open a browser and navigate to:
   - SwaggerUI: https://localhost:7096/swagger (HTTPS)
   - or http://localhost:5023 (HTTP)

## Development Requirements

- .NET 9.0 SDK
- Visual Studio 2022+ or VS Code
- Windows OS (tested on Windows)