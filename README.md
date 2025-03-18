# ToDoList Application

A task management system built with ASP.NET Core and Clean Architecture principles.

## 🚀 Technologies

- **ASP.NET Core API** (Minimal API approach)
- **MediatR** for implementing the mediator pattern and handling commands/queries
- **ErrorOr** library for implementing the Result pattern
- **Swagger** for comprehensive API documentation
- **FluentValidation** for robust request validation

## 🧪 Testing Stack

- **FluentAssertions** for more expressive and readable test assertions
- **Moq** for creating mock objects in unit tests
- **xUnit** as the testing framework

## 🏗️ Architecture

This project implements **Clean Architecture** with **Vertical Slice Architecture** principles:

```
├── ToDoTask.Api        # API endpoints, middleware, configuration
├── ToDoTask.Application  # Application logic, commands, queries
├── ToDoTask.Domain     # Domain entities and business rules
├── ToDoTask.Infrastructure  # Data access, external services
└── ToDoTask.Tests      # Unit and integration tests
```

### Why Minimal API?

After years of using traditional MVC controllers, I've fallen in love with the Minimal API approach due to:

- **Improved readability** - less boilerplate code
- **Better scalability** - easier to maintain as the application grows
- **Focused endpoints** - each endpoint handles a specific concern
- **Simplified dependency injection** - more straightforward service registration

## 🔧 Getting Started

### Prerequisites

- .NET 9.0
- Docker (optional, for containerized deployment)

### Running the Application

#### Using Docker

Navigate to the repository root directory and run:

```bash
cd ToDoSol
docker-compose up -d
```

The API will be available at `https://localhost:7143`.
