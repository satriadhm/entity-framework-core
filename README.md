# Entity Framework Core with MySQL

## Overview
This project is a C# implementation utilizing Entity Framework Core with MySQL as the database provider. It includes CRUD operations and employs dotenv.net for managing environment variables.

## Features
- Integration with Entity Framework Core for ORM-based database interactions
- MySQL as the database backend
- Dependency Injection (DI) using `ServiceCollection`
- Environment variable management for database configuration
- Support for database migrations

## Project Structure
```
📦 satriadhm-entity-framework-core
┣ 📜 README.md
┣ 📜 LICENSE.txt
┣ 📜 Program.cs
┣ 📜 AppDBContext.cs
┣ 📜 DBService.cs
┣ 📜 DBModel.cs
┣ 📜 IDBRepository.cs
┣ 📜 DBConn.cs
┣ 📜 CSharpImplementation.csproj
┣ 📜 CSharpImplementation.sln
┗ 📂 Migrations
    ┣ 📜 20250129150647_InitialCreate.Designer.cs
    ┣ 📜 20250129150647_InitialCreate.cs
    ┗ 📜 AppDBContextModelSnapshot.cs
```

## Installation and Setup

### Install Dependencies
Execute the following commands to install the necessary NuGet packages:
```sh
# Install Entity Framework Core and MySQL provider
 dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2
 dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.2
 dotnet add package Microsoft.EntityFrameworkCore.Relational --version 8.0.2
 dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.2
 dotnet add package dotenv.net --version 3.2.1
```

### Configure Environment Variables
Create a `.env` file in the root directory with the following content:
```
DB_SERVER=your_server
DB_NAME=your_database
DB_USER=your_username
DB_PASSWORD=your_password
```

### Apply Migrations and Create Database
Run the following commands to initialize the database:
```sh
# Generate migrations
 dotnet ef migrations add InitialCreate

# Apply migrations to the database
 dotnet ef database update
```

## Usage

### Running the Application
```sh
 dotnet run
```


## Troubleshooting
### Error: "An error occurred while saving the entity changes"
Solution: Ensure the database tables exist and execute:
```sh
dotnet ef database update
```

### Error: "The property 'DBModel.Id' is part of a key and so cannot be modified"
Solution: Modify only non-primary key fields when updating an entity.

### Error: "Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbContextOptions'"
Solution: Add a parameterless constructor in `AppDBContext.cs`:
```csharp
public AppDBContext() { }
```

## License
This project is licensed under the MIT License. Refer to `LICENSE.txt` for details.

## Contributors
- [satriadhm] - Developer

## Future Improvements
- Implementation of unit tests
- Integration of logging for error tracking
- Support for multiple databases (e.g., PostgreSQL, SQL Server)

This document provides an overview of the setup and functionality of the project.

