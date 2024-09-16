## .Net 8 BE API with Onion Architecture

### Features:
- [X] JWT Authentication
- [X] Role-Based Authorization
- [X] Entity Framework Core with PostgreSQL
- [X] Repository Pattern
- [X] Unit of Work Pattern
- [X] Dependency Injection
- [X] AutoMapper for Object-Object Mapping
- [X] FluentValidation for Request Validation
- [X] MediatR for CQRS (Command Query Responsibility Segregation)
- [X] Swagger for API Documentation
- [X] Exception Handling Middleware
- [ ] Health Checks
- [ ] Caching with Redis
- [ ] Background Services with Hosted Services
- [ ] Rate Limiting
- [ ] Logging with Serilog

### Install | Deployment:
- You need a PostgreSQL Database and fill the configuration of the database in `appsettings.Development.json`/`appsettings.Production.json`.
- Please run the migration command in the terminal:
  - Navigate to the `QuotationSystem.Persistence` folder:
    ```sh
    cd QuotationSystem.Persistence
    ```
  - Add the initial migration:
    ```sh
    dotnet ef migrations add InitialMigration --startup-project ../QuotationSystem.API --context AppDbContext
    ```
  - Update the database:
    ```sh
    dotnet ef database update --startup-project ../QuotationSystem.API --context AppDbContext
    ```