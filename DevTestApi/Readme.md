# Development Test API

## Tools and Tech
- Visual Studio 2019
- SQLite
- .NET 5.0
- Swagger
- Repository pattern
- ASP NET Core Identity

## Implementation

- This API have simple implementation of repository pattern.Repository pattern good for testing, easy to implement, easy to change data store without changing the API.
- Swagger is used for documentation, swagger is easy to understand for both developer and non-developer. 
- SQLIte for easy implementation for test development. 
- ASP NET Identity is proven, tested and harden solution for security, in this case implementation was done manually without using pre build schema. 
- In this API some method implement to show the common scenarios: Pagination, Security Policy, Clean structure, AutoMapper. Purpose to show implementation of various scenario.

## Building a sample
``` 
dotnet build
dotnet run
```