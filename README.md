# Albatross-ITPE3200-Webapplikasjoner

# Albatross - Albanian Language Learning Platform

A web application for learning Albanian through interactive quizzes and gamification.

## Technology Stack

- **.NET Version:** .NET 8.0
- **Framework:** ASP.NET Core MVC
- **Database:** SQLite with Entity Framework Core 8.0
- **Authentication:** ASP.NET Core Identity
- **Frontend:** Bootstrap 5, jQuery
- **No Node.js required** (client-side libraries are included)

## Prerequisites

- .NET 8.0 SDK

## How to Run the Application

1. Extract the ZIP file to your desired location

2. Open a terminal/PowerShell and navigate to the Albatross project folder:
   ```bash
   cd Albatross-ITPE3200-Webapplikasjoner\Albatross
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

6. Open your browser


- **Username:** admin
- **Email:** admin@albatross.com
- **Password:** Admin123!

## Features

- User registration and authentication
- Interactive quiz system (A1 module with alphabet and verb quizzes)
- Dashboard for tracking progress
- Admin functionality for managing content
- Bootstrap-based responsive design
- Role-based access control (Admin/Player roles)

## Database Structure

The application uses SQLite with the following main entities:
- Users (with Identity integration)
- Items
- Modules and ModuleTopics
- Questions and AnswerOptions
- Rewards and Inventories

## Project Structure


```
Albatross/
├── Controllers/      # MVC Controllers
├── Models/          # Entity Models
├── Views/           # Razor Views
├── DAL/             # Data Access Layer (Repository pattern)
├── ViewModels/      # View Models for data transfer
├── wwwroot/         # Static files (CSS, JS, images)
└── Migrations/      # Entity Framework Migrations
```

## Architecture

The application follows the Repository Pattern and DAL (Data Access Layer) for data operations:

- **Repository Pattern:** Implemented in the `DAL/` folder
  - `IItemRepository` - Interface defining data operations
  - `ItemRepository` - Concrete implementation using Entity Framework Core
  - Provides abstraction between business logic and data access
- **Controllers use repositories** for database operations rather than accessing DbContext directly
- This pattern improves testability and maintainability

## AI-Assisted Development
This project utilized AI tools for development assistance in the following areas:

- **Authentication Setup:** Guidance on implementing ASP.NET Identity with role-based access control
- **Repository Pattern Implementation:** Assistance in setting up the repository pattern and dependency injection
- **Error Handling:** Help in adding proper error handling and logging with ILogger
- **Code Structure:** Suggestions for organizing controllers, models, and views
- **Database Migrations:** Help resolving migration conflicts and database setup issues
- **Bug Fixes:** Troubleshooting and fixing compilation and runtime errors

**Note:** All code was reviewed, tested, and understood by the development team before integration. AI assistance was used as a learning tool and for productivity, but all final implementation decisions were made by the developers.

Further, the group utilized Demos posted in Canvas, created by Baifan Zhou. Code from the demos is both copied and/or used as inspiration and developed further to fit our needs. 
