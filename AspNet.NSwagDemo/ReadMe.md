# ASP.NET Core API with NSwag Demo

## Table of Contents
1. [Overview](#overview)
2. [Platforms](#platforms)
3. [Features](#features)
4. [Getting Started](#getting-started)
    - [Installation](#getting-started)
    - [Running the Project](#getting-started)
5. [NuGet Package Configuration](#nuget-package-configuration)
    - [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](#microsoftaspnetcorediagnosticsentityframeworkcore-902)
    - [Microsoft.AspNetCore.OpenApi](#microsoftaspnetcoreopenapi-902)
    - [Microsoft.EntityFrameworkCore.InMemory](#microsoftentityframeworkcoreinmemory-902)
    - [Swashbuckle.AspNetCore](#swashbuckleaspnetcore-720)
6. [Database](#database)
7. [Minimal API Endpoints](#minimal-api-endpoints)
8. [OpenAPI Documentation](#openapi-documentation)
    - [Todo API](#todo-api)
9. [Launch Settings](#launch-settings)
    - [Launch Profiles](#launch-profiles)
10. [Project Structure](#project-structure)
11. [Models](#models)
     - [Todo Entity](#todo-entity)
     - [TodoItemDTO](#todoitemdto)
12. [Contributing](#contributing)
13. [License](#license)

## Overview
This project demonstrates the implementation of OpenAPI (Swagger) documentation using NSwag in an ASP.NET Core Web API. It showcases best practices for API documentation and testing.

## Platforms

![Framework](https://img.shields.io/badge/Framework-.NET%209.0-purple?style=for-the-badge) 
![Platform](https://img.shields.io/badge/Platforms-Windows%20%7C%20Linux%20%7C%20mac%20OS-blue?style=for-the-badge)
![OpenAPI](https://img.shields.io/badge/OpenAPI-3.0.1-darkgreen?style=for-the-badge)    

## Features
- OpenAPI documentation with NSwag
- Minimal API endpoints
- RESTful API design
- Swagger UI integration
- API versioning
- Automatic documentation generation
- Entity Framework Core with InMemory database
- CRUD operations for Todo items
- Batch operations support
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
    - Swagger UI: 
        - HTTPS: `https://localhost:7030/swagger`
        - HTTP: `http://localhost:5075/swagger`
    - API Endpoints:
        - HTTPS: `https://localhost:7030/todoitems`
        - HTTP: `http://localhost:5075/todoitems`
    - OpenAPI Documentation:
        - HTTPS: `https://localhost:7030/swagger/v1/swagger.json`
        - HTTP: `http://localhost:5075/swagger/v1/swagger.json`

The API will automatically open in your default browser when you run the application.

## NuGet Package Configuration
The following NuGet packages are required for this project:

### Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore (9.0.2)
- Provides middleware for Entity Framework Core error pages
- Enables detailed database error information during development
```powershell
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 9.0.2
```

### Microsoft.AspNetCore.OpenApi (9.0.2)
- Enables OpenAPI description for ASP.NET Core APIs
- Required for Swagger documentation generation
```powershell
dotnet add package Microsoft.AspNetCore.OpenApi --version 9.0.2
```

### Microsoft.EntityFrameworkCore.InMemory (9.0.2)
- Provides in-memory database provider for Entity Framework Core
- Useful for testing and development scenarios
```powershell
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 9.0.2
```

### Swashbuckle.AspNetCore (7.2.0)
- Adds Swagger tools for documenting APIs built on ASP.NET Core
- Includes Swagger UI for API testing and exploration
```powershell
dotnet add package Swashbuckle.AspNetCore --version 7.2.0
```

```xml
<ItemGroup>
<PackageReference Include="NSwag.AspNetCore" Version="14.0.3" />
<PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="9.0.2" />
<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.2" />
</ItemGroup>
```
## Database

The application uses Entity Framework Core with an InMemory database provider, pre-populated with sample todo items on startup.

## Minimal API Endpoints

The following endpoints are available in the API:

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

## OpenAPI Documentation
The project uses OpenAPI (Swagger) to document and test its APIs. Swagger UI is automatically generated and available at `http://localhost:<port>/swagger`. The following endpoints are documented:

### Todo API
- **GET /api/todo**  
    Retrieves a list of all Todo items.  
    **Response:** 200 (OK) - List of Todo items  
    **Error:** 500 (Internal Server Error)

- **GET /api/todo/{id}**  
    Retrieves a specific Todo item by ID.  
    **Response:** 200 (OK) - Todo item  
    **Error:** 404 (Not Found), 500 (Internal Server Error)

- **POST /api/todo**  
    Creates a new Todo item.  
    **Request Body:**  
    ```json
    {
        "id": 1,
        "name": "Sample Task",
        "isComplete": false
    }
    ```
    **Response:** 201 (Created) - Created Todo item  
    **Error:** 400 (Bad Request), 500 (Internal Server Error)

- **PUT /api/todo/{id}**  
    Updates an existing Todo item by ID.  
    **Request Body:**  
    ```json
    {
        "id": 1,
        "name": "Updated Task",
        "isComplete": true
    }
    ```
    **Response:** 200 (OK) - Updated Todo item  
    **Error:** 400 (Bad Request), 404 (Not Found), 500 (Internal Server Error)

- **DELETE /api/todo/{id}**  
    Deletes a specific Todo item by ID.  
    **Response:** 204 (No Content)  
    **Error:** 404 (Not Found), 500 (Internal Server Error)

---
## Launch Settings

Development environment settings:
The `launchSettings.json` file in the `Properties` folder configures how the application launches in different environments. This configuration includes:

### Launch Profiles
The file contains two primary launch profiles:

- **HTTP Profile**
    - Runs on port 5075
    - Browser launch enabled
    - Opens Swagger UI automatically
    - Development environment

- **HTTPS Profile**
    - Primary port: 7030 (HTTPS)
    - Secondary port: 5075 (HTTP)
    - Auto-launches browser
    - Opens Swagger UI automatically
    - Development environment

Both profiles are configured to:
- Use `dotnetRunMessages` for enhanced console output
- Launch in Development environment
- Open the Swagger UI interface by default
- Enable automatic browser launch on startup

These settings control the application's startup behavior and can be modified to suit different development needs.

```json
{
    "profiles": {
        "http": {
            "commandName": "Project",
            "dotnetRunMessages": true,
            "launchBrowser": true,
            "launchUrl": "swagger",
            "applicationUrl": "http://localhost:5075",
            "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            }
        },
        "https": {
            "commandName": "Project",
            "dotnetRunMessages": true,
            "launchBrowser": true,
            "launchUrl": "swagger",
            "applicationUrl": "https://localhost:7030;http://localhost:5075",
            "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            }
        }
    }
}
```

The launch settings define two profiles:
- HTTP profile on port 5075 with Swagger UI
- HTTPS profile on port 7030 (with HTTP on 5075) with Swagger UI

Both profiles are configured for development environment and will launch the browser to the Swagger documentation interface.

## Project Structure
```
AspNet.NSwagDemo/
├── 📁 Properties/
│   └── ⚙️ launchSettings.json  # Launch settings file
├── 📄 Program.cs               # Application entry point and API configuration
├── 📁 Models/
│   ├── 📄 Todo.cs             # Todo entity model
│   ├── 📄 Tag.cs              # Tag entity model
│   └── 📄 TodoItemDTO.cs      # Data Transfer Object for Todo
├── 📁 Data/
│   └── 📄 TodoDb.cs           # DbContext configuration
├── ⚙️ appsettings.json         # Application settings
├── ⚙️ appsettings.Development.json
└── 📄 AspNet.NSwagDemo.csproj
```

## Models

### Todo Entity
```csharp
public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public Tag Tag { get; set; } = new();
}
```

### TodoItemDTO
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

---

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.


[Go to TOC](#table-of-contents)