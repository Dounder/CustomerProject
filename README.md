# Clean Architecture Solution

This repository is organized following the principles of Clean Architecture. Below is the structure and description of each project within the solution.

## Projects

### CleanArch.Application
Contains application business logic and use cases.
- `Dependencies/`
- `Common/`
- `Mappings/`
- `UseCases/`
- `ConfigureServices.cs`

### CleanArch.Domain
Includes domain entities, enums, exceptions, and interfaces.
- `Dependencies/`
- `Common/`
- `Entities/`
- `Enums/`
- `Exceptions/`
- `Interfaces/`

### CleanArch.Infrastructure
Implements persistence and infrastructure concerns.
- `Dependencies/`
- `Data/`
    - `Migrations/`
- `Repositories/`
- `ConfigureServices.cs`

### CleanArch.WebAPI
The entry point for the web API, containing controllers and middleware.
- `Dependencies/`
- `Properties/`
- `Controllers/`
- `Middlewares/`
- `appsettings.json`
- `appsettings.Development.json`
- `CleanArch.http`
- `compose.yml`
- `Dockerfile`
- `Program.cs`

## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

- .NET 8.0 SDK
- Docker (optional)

### Installation

1. Clone the repo
2. Navigate to the root directory
3. Run `dotnet restore`
4. Run `dotnet run --project CleanArch.WebAPI`
