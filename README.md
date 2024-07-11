# subscriptionexercise
Exercise 2

# Notes

Swagger is enabled, you only need to access the Crayon.Api for all the features. See instructions below.

While a lot of effort was done to make the app feel "production" ready.. there is still a lot that needed to be done

- FluentValidation
- Better error handling
- UnitTests

The project uses Clean Architecture with CQRS, Repository pattern, UnitOfWork pattern, and etc.

Obviously Clean Architecture is not original.. and a lot of training was done via [Dome](https://dometrain.com) prior to the interview but also refresher during the interview process. While Dometrain was a resource for the arcthitecture - it's also very simliar to my work past experience. I needed Dometrain as .Net core is new to me and also EntityFramework refresher (FNZ Group used their own ORM).

# How to Setup and run the application

[//]: # (instructions for mac - should be same for windows)
git clone 
[//]: # (Docker)
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SecretPassword123\!" -p 1433:1433 --name crayon -d mcr.microsoft.com/mssql/server:2022-latest

[//]: # (Dotnet)
[//]: # (dotnet ef migrations add InitialCreate -p src/Crayon.Repository.Infrastructure -s src/Crayon.Api)

dotnet ef database update -p src/Crayon.Repository.Infrastructure -s src/Crayon.Api

dotnet run -p src/Crayon.Api
dotnet run -p src/CloudComputingProvider.Api








