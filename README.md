# subscriptionexercise
Exercise 2

# Notes

Swagger is enabled, you only need to access the Crayon.Api for all the features. See instructions below.

While a lot of effort was done to make the app feel "production" ready.. there is still a lot that needed to be done

- Authentication for Customer
- FluentValidation
- IOption usage for better configuration
- Better error handling
- UnitTests

The project uses Clean Architecture with CQRS, Repository pattern, UnitOfWork pattern, and etc.

# How to Setup and run the application

## instructions for mac - should be same for windows
## Git
clone the repo

## Docker
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SecretPassword123" -p 1433:1433 --name crayon -d mcr.microsoft.com/mssql/server:2022-latest

## DotNet
dotnet ef database update -p src/Crayon.Repository.Infrastructure -s src/Crayon.Api

dotnet run -p src/Crayon.Api
dotnet run -p src/CloudComputingProvider.Api

// if you want to re-run migrations delete Migrations folder first
// dotnet ef migrations add InitialCreate -p src/Crayon.Repository.Infrastructure -s src/Crayon.Api
// then run the database update

