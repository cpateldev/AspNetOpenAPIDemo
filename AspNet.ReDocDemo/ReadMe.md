# ASP.NET Core ReDoc API Documentation Demo

## Table of Contents
- [Overview](#overview)
- [Platforms](#platforms)
- [Features](#features)
- [Getting Started](#getting-started)
- [NuGet Package Configuration](#nuget-package-configuration)
    - [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](#microsoftaspnetcorediagnosticsentityframeworkcore-902)
    - [Microsoft.AspNetCore.OpenApi](#microsoftaspnetcoreopenapi-902)
    - [Microsoft.EntityFrameworkCore.InMemory](#microsoftentityframeworkcoreinmemory-902)
    - [Swashbuckle.AspNetCore.ReDoc](#swashbuckleaspnetcoreredoc-650)
- [Database](#database)
- [Minimal API Endpoints](#minimal-api-endpoints)
- [OpenAPI Documentation](#openapi-documentation)
    - [Todo API](#todo-api)
- [Launch Settings](#launch-settings)
    - [Launch Profiles](#launch-profiles)
- [Project Structure](#project-structure)
- [Models](#models)
    - [Todo Entity](#todo-entity)
    - [TodoItemDTO](#todoitemdto)
- [Contributing](#contributing)
- [License](#license)

## Overview
This project demonstrates the implementation of ReDoc documentation for ASP.NET Core Web API. ReDoc provides a responsive, customizable, and user-friendly API documentation interface.

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
  - ReDoc UI: `https://localhost:7266/api-docs` or `http://localhost:5074/api-docs`  
  - API Base URL: 
    - HTTPS: `https://localhost:7266/todoitems`
    - HTTP: `http://localhost:5074/todoitems`

The documentation interfaces are:
- ReDoc UI: A clean, responsive, three-panel design documentation
- Swagger UI: Interactive API testing and documentation interface


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

### Swashbuckle.AspNetCore.ReDoc (6.5.0)
- Adds ReDoc documentation UI for ASP.NET Core APIs
- Provides a responsive, customizable API reference documentation
```powershell
dotnet add package Swashbuckle.AspNetCore.ReDoc --version 6.5.0
```

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="9.0.2" />
  <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.2" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.2" />
  <PackageReference Include="Swashbuckle.AspNetCore.ReDoc" Version="6.5.0" />
</ItemGroup>
```
## Database

The application uses Entity Framework Core with an InMemory database provider, pre-populated with sample todo items on startup.

## Minimal API Endpoints

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
The project uses OpenAPI (Swagger) to document and test its APIs. Swagger UI is automatically generated and available at `http://localhost:<port>/api-docs`. The following endpoints are documented:

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
    - Runs on port 5074
    - Browser launch disabled
    - Development environment

- **HTTPS Profile**
    - Primary port: 7266 (HTTPS)
    - Secondary port: 5074 (HTTP)
    - Auto-launches browser
    - Opens Swagger UI automatically
    - Development environment

These settings control the application's startup behavior and can be modified to suit different development needs.

The configuration below specifies the development launch settings:

```json
{
  "http": {
    "commandName": "Project",
    "dotnetRunMessages": true,
    "launchBrowser": false,
    "applicationUrl": "http://localhost:5074"
  },
  "https": {
    "commandName": "Project",
    "dotnetRunMessages": true,
    "launchBrowser": true,
    "launchUrl": "swagger",
    "applicationUrl": "https://localhost:7266;http://localhost:5074"
  }
}
```

## Project Structure
```
AspNet.ReDocDemo/
├── 📁 Properties/
│   └── ⚙️ launchSettings.json  # Launch settings file
├── 📄 Program.cs               # Application entry point and API configuration
├── 📄 Todo.cs                  # Todo entity model
├── 📄 TodoDb.cs                # DbContext configuration
├── 📄 TodoItemDTO.cs           # Data Transfer Object for Todo
├── ⚙️ appsettings.json         # Application settings
├── ⚙️ appsettings.Development.json
└── 📄 AspNet.ReDocDemo.csproj
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