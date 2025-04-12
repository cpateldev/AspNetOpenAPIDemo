# AspNetOpenAPIDemo

![Framework](https://img.shields.io/badge/Framework-.NET%209.0-purple?style=for-the-badge) 
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Linux%20%7C%20macOS-blue?style=for-the-badge)  

## Overview

A minimal API demo project showcasing Todo management with OpenAPI documentation using ASP.NET Core 9.0.

---
## Features

- Minimal API architecture
- Entity Framework Core with InMemory database
- OpenAPI/Swagger documentation
- CRUD operations for Todo items
- Batch operations support
- DTO pattern implementation

---

## NuGet Package Dependencies
The project uses the following NuGet packages:

1. **Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore**  
    Provides middleware for Entity Framework Core error pages.  
    ```bash
    dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
    ```

2. **Microsoft.AspNetCore.OpenApi**  
    Provides API support for OpenAPI (Swagger) functionality in ASP.NET Core.  
    ```bash
    dotnet add package Microsoft.AspNetCore.OpenApi
    ```

3. **Microsoft.EntityFrameworkCore.InMemory**  
    Provides in-memory database provider for Entity Framework Core.  
    ```bash
    dotnet add package Microsoft.EntityFrameworkCore.InMemory
    ```

---

## Project Structure
Below is the structure of the project:

```
AspNetOpenAPIDemo/ 📁
├── Properties/ 📁
│   └── launchSettings.json ⚙️
├── bin/ 📁
├── obj/ 📁
├── appsettings.Development.json ⚙️
├── appsettings.json ⚙️
├── AspNetOpenAPIDemo.csproj 📄
├── AspNetOpenAPIDemo.csproj.user 📄
├── AspNetOpenAPIDemo.http 📄
├── AspNetOpenAPIDemo.sln 📄
├── Program.cs 📄
├── ReadMe.md 📄
├── ToDo.cs 📄
├── ToDoDb.cs 📄
└── TodoItemDTO.cs 📄
```
---


## Database

The application uses Entity Framework Core with an InMemory database provider, pre-populated with sample todo items on startup.

## Minimal API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `api/todoitems` | Get all todo items |
| GET | `api/todoitems/complete` | Get completed todo items |
| GET | `api/todoitems/{id}` | Get a specific todo item |
| POST | `api/todoitems` | Create a new todo item |
| PUT | `api/todoitems/{id}` | Update an existing todo item |
| PATCH | `api/todoitems/{id}` | Partially update a todo item |
| DELETE | `api/todoitems/{id}` | Delete a todo item |
| POST | `api/todoitems/batch` | Create multiple todo items |


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
The application can be launched in two modes:

### HTTP Profile
- Runs on http://localhost:5173
- Browser launch disabled by default
- Development environment

### HTTPS Profile
- Runs on https://localhost:7013 and http://localhost:5173
- Automatically opens browser on launch
- Opens the OpenAPI specification (openapi/v1.json) by default
- Development environment

---

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

4. Access Swagger UI at `http://localhost:<port>/openapi/v1.json`
5. Access web api at `https://localhost:<port>/api/todoitems`
---

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

---

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.
