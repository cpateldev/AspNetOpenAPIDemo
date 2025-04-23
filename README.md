# ASP.Net Open API documentation demo

## Table of Contents
1. [Overview](#overview)
2. [Prerequisites](#prerequisites)
3. [Installation Guide](#installation-guide)
4. [Project Structure](#project-structure)
5. [API Documentation](#api-documentation)
6. [Configuration Guide](#configuration-guide)
7. [Development Guide](#development-guide)
8. [Troubleshooting](#troubleshooting)
9. [Examples](#examples)
10. [Security Considerations](#security-considerations)
11. [Contribution Guidelines](#contribution-guidelines)



## Overview
This project is a modern ASP.NET Core application that demonstrates the use of OpenAPI, ReDoc, Swagger UI, and Scalar for API documentation and UI implementations. It includes a sample Todo API for managing tasks.



## Prerequisites
Ensure the following software is installed on your system:
- **.NET SDK**: Version 9.0 or higher
- **Visual Studio 2022**: Version 17.7 or higher with ASP.NET and web development workload
- **Node.js** (if applicable): Version 16.x or higher
- **Postman** (optional): For testing APIs
- **Git**: For version control



## Installation Guide
Follow these steps to set up the project:
1. Clone the repository:


## Project Structure

### Solution Overview
The solution consists of the following projects:
- **[AspNetOpenAPIDemo](/AspNetOpenAPIDemo/README.md)**: Basic OpenAPI implementation.
- **[AspNet.SwaggerUIDemo](/AspNet.SwaggerUIDemo/README.md)**: Implements native Swagger UI for API documentation.
- **[AspNet.SwashbuckleDemo](/AspNet.SwashbuckleDemo/README.md)**: Uses Swashbuckle for Swagger UI integration.
- **[AspNet.NSwagDemo](/AspNet.NSwagDemo/README.md)**: Showcases NSwag Studio integration for API documentation and client generation.
- **[AspNet.ScalarDemo](/AspNet.ScalarDemo/README.md)**: Implements Scalar for advanced API documentation.
- **[AspNet.ReDocDemo](/AspNet.ReDocDemo/README.md)**: Demonstrates ReDoc integration for API documentation.



### Common Components
- **`TodoDb`**: In-memory database for managing Todo items.
- **`PopulateTodoDB`**: Seeds the database with sample data.
- **`Program.cs`**: Entry point for each project.



## API Documentation
### Endpoints
#### 1. `GET /todoitems`
- **Description**: Retrieves all Todo items.
- **Query Parameters**: None
- **Response**:
- **Response Codes**:
  - `200 OK`: Successfully retrieved items.

#### 2. `POST /todoitems`
- **Description**: Creates a new Todo item.
- **Request**:
- **Response**:
- **Response Codes**:
  - `201 Created`: Successfully created the item.
  - `400 Bad Request`: Invalid input.

### Authentication
- No authentication is required for this demo.



## Configuration Guide
### ReDoc Configuration
- Modify `options.SpecUrl` in `Program.cs` to point to the desired OpenAPI specification file.

### Swagger UI Configuration
- Update `SwaggerEndpoint` in `Program.cs` to customize the Swagger UI.

### Scalar Configuration
- Customize the `AddDocumentTransformer` method in `Program.cs` to modify API metadata.



## Development Guide
### Debugging
1. Set breakpoints in Visual Studio.
2. Run the project in Debug mode (`F5`).
3. Use the integrated debugger to inspect variables and execution flow.

### Testing
- Use Postman or curl to test API endpoints.
- Run unit tests (if available):


## Troubleshooting
### Common Issues
1. **Database not seeded**:
   - Ensure `PopulateTodoDB` is called in `Program.cs`.
2. **API not accessible**:
   - Verify the application is running on the correct port.
   - Check firewall settings.



## Examples
### Use Case 1: Retrieve all Todo items
### Use Case 2: Add a new Todo item


## Security Considerations
- Use HTTPS for secure communication.
- Validate all user inputs to prevent injection attacks.
- Implement authentication and authorization for production environments.



## Contribution Guidelines
1. Fork the repository.
2. Create a feature branch:
3. Commit your changes:
4. Push to your branch:
5. Create a pull request.



## License
This project is licensed under the MIT License. See `LICENSE` for details.
