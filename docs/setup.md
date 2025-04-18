# Create a solution 
dotnet new sln -n SportClub

# Create the projects
dotnet new web -n SportClub.Api
dotnet new classlib -n SportClub.Domain
dotnet new classlib -n SportClub.Application
dotnet new classlib -n SportClub.Infrastructure

# Add projects to the solution
dotnet sln SportClub.sln add SportClub.Api SportClub.Application SportClub.Domain SportClub.Infrastructure

# Add references between projects
dotnet add SportClub.Api reference SportClub.Domain SportClub.Application SportClub.Infrastructure
dotnet add SportClub.Application reference SportClub.Domain
dotnet add SportClub.Infrastructure reference SportClub.Domain
dotnet add SportClub.Infrastructure reference SportClub.Application 

# Add projects to the solution

# MediatR for CQRS
dotnet add SportClub.Application package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add SportClub.Application package FluentValidation
dotnet add SportClub.Api package Microsoft.EntityFrameworkCore.Design
dotnet add SportClub.Api package Swashbuckle.AspNetCore

# EF Core and SQL Server Provider
dotnet add SportClub.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add SportClub.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite
dotnet add SportClub.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add SportClub.Infrastructure package Microsoft.Extensions.Configuration.FileExtensions
dotnet add SportClub.Infrastructure package Microsoft.Extensions.Configuration.Json
dotnet add SportClub.Api package Microsoft.EntityFrameworkCore.Design
dotnet add SportClub.Api package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add SportClub.Api package System.IdentityModel.Tokens.Jwt

# Init EF Core
dotnet tool update --global dotnet-ef
dotnet ef migrations add InitialCreate --verbose --project SportClub.Infrastructure --context SportClub.Infrastructure.Persistence.ApplicationDbContext --startup-project SportClub.Api
dotnet ef database update --verbose --project SportClub.Infrastructure --context SportClub.Infrastructure.Persistence.ApplicationDbContext --startup-project SportClub.Api

dotnet ef migrations add InitialCreate --verbose --project SportClub.Infrastructure --context SportClub.Infrastructure.Persistence.ApplicationDbContext --startup-project SportClub.Api


# Configure git repo
git init
git add .
git commit -m "Initial commit for SportClub project setup"
git remote add origin https://github.com/jallalbrahimi/SportClub.git
git branch -M main
git pull origin main
git pull --rebase origin main



 npm create vite@latest sportclub.client --template lit


