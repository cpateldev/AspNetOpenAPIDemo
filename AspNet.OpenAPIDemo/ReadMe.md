# Asp.Net Open API Demo

## Table of Contents
- [Overview](#overview)
- [Platforms](#platforms)
- [Features](#features)
- [Getting Started](#getting-started)
- [NuGet Package Configuration](#nuget-package-configuration)
    - [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](#microsoftaspnetcorediagnosticsentityframeworkcore-902)
    - [Microsoft.AspNetCore.OpenApi](#microsoftaspnetcoreopenapi-902)
    - [Microsoft.EntityFrameworkCore.InMemory](#microsoftentityframeworkcoreinmemory-902)
    - [Swashbuckle.AspNetCore](#swashbuckleaspnetcore-720)
- [Database](#database)
- [Minimal API Endpoints](#minimal-api-endpoints)
- [OpenAPI Documentation](#openapi-documentation)
    - [Todo API](#todo-api)
- [Launch Settings](#launch-settings)
    - [Launch Profiles](#launch-profiles)
- [Contributing](#contributing)
- [License](#license)

## Overview

A minimal API demo project showcasing Todo management with OpenAPI documentation using ASP.NET Core 9.0.

## Platforms

![Framework](https://img.shields.io/badge/Framework-.NET%209.0-purple?style=for-the-badge) 
![Platform](https://img.shields.io/badge/Platforms-Windows%20%7C%20Linux%20%7C%20mac%20OS-blue?style=for-the-badge)
![OpenAPI](https://img.shields.io/badge/OpenAPI-3.0.1-darkgreen?style=for-the-badge)  

## Features

- Minimal API architecture
- Entity Framework Core with InMemory database
- OpenAPI/Swagger documentation
- CRUD operations for Todo items
- Batch operations support
- DTO pattern implementation

## Getting Started
1. Clone the repository:
    ```bash
    git clone https://github.com/your-repo/AspNetOpenAPIDemo.git
    cd AspNetOpenAPIDemo
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

4. Access Swagger UI at `http://localhost:5064/swagger` or `https://localhost:7041/swagger`
5. Access Web API at `http://localhost:5064/todoitems` or `https://localhost:7041/todoitems`
---

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
```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="9.0.2" />
  <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.2" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="9.0.2" />
</ItemGroup>
```

## Database

The application uses Entity Framework Core with an InMemory database provider, pre-populated with sample todo items on startup.

## Minimal API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/todoitems` | Get all todo items |
| GET | `/todoitems/complete` | Get completed todo items |
| GET | `/todoitems/{id}` | Get a specific todo item |
| POST | `/todoitems` | Create a new todo item |
| PUT | `/todoitems/{id}` | Update an existing todo item |
| PATCH | `/todoitems/{id}` | Partially update a todo item |
| DELETE | `/todoitems/{id}` | Delete a todo item |
| POST | `/todoitems/batch` | Create multiple todo items |

## OpenAPI Documentation
The project uses OpenAPI (Swagger) to document and test its APIs. Swagger UI is automatically generated and available at `http://localhost:<port>/swagger`. 

The following endpoints are documented:

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

## Launch Settings

Development environment settings:
The `launchSettings.json` file in the `Properties` folder configures how the application launches in different environments. This configuration includes:

### Launch Profiles
The file contains two primary launch profiles:

- **HTTP Profile**
    - Runs on port 5070
    - Browser launch disabled
    - Development environment

- **HTTPS Profile**
    - Primary port: 7013 (HTTPS)
    - Secondary port: 5070 (HTTP)
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
    "applicationUrl": "http://localhost:5070"
  },
  "https": {
    "commandName": "Project",
    "dotnetRunMessages": true,
    "launchBrowser": true,
    "launchUrl": "swagger",
    "applicationUrl": "https://localhost:7013;http://localhost:5070"
  }
}
```

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

[Go to TOC](#table-of-contents)