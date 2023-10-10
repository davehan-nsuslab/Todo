Todo list (Clean architecture sample project)
---
## Clean architecture 프로젝트 구조
```angular2html
.
├── Core
│   ├── Todo.Application
│   │   ├── Exceptions
│   │   ├── Features
│   │   ├── MappingProfile
│   │   ├── Models
│   │   ├── PipelineBehaviors
│   │   ├── Repositories
│   │   ├── Services
│   │   ├── Todo.Application.csproj
│   └── Todo.Domain
│       ├── Common
│       ├── Entities
│       ├── Todo.Domain.csproj
├── Infrastructure
│   ├── Todo.Infrastructure
│   │   ├── Todo.Infrastructure.csproj
│   └── Todo.Persistence
│       ├── Contexts
│       ├── Migrations
│       ├── Repositories
│       ├── Services
│       ├── Todo.Persistence.csproj
├── Presentation
│   └── Todo.WebApi
│       ├── Controllers
│       ├── Middlewares
│       ├── Program.cs
│       ├── Properties
│       ├── Todo.WebApi.csproj
│       ├── appsettings.Development.json
│       ├── appsettings.json
├── Tests
│   ├── GlobalUsings.cs
│   ├── Tests.csproj
└── Todo.sln
```

## 프로젝트 생성
```bash
$ dotnet new sln -n Todo

# Core
$ dotnet new classlib -n Todo.Domain -o ./Core/Todo.Domain
$ dotnet new classlib -n Todo.Application -o ./Core/Todo.Application

# Infrastructure
$ dotnet new classlib -n Todo.Infrastructure -o ./Infrastructure/Todo.Infrastructure
$ dotnet new classlib -n Todo.Persistence -o ./Infrastructure/Todo.Persistence

# Presentation
$ dotnet new webapi -n Todo.WebApi -o ./Presentation/Todo.WebApi

# Tests
$ dotnet new xunit -n Tests -o ./Tests/Tests
```

## Reference 추가
```bash
$ dotnet sln add ./Core/Todo.Domain/Todo.Domain.csproj
$ dotnet sln add ./Core/Todo.Application/Todo.Application.csproj
$ dotnet sln add ./Infrastructure/Todo.Infrastructure/Todo.Infrastructure.csproj
$ dotnet sln add ./Infrastructure/Todo.Persistence/Todo.Persistence.csproj
$ dotnet sln add ./Presentation/Todo.WebApi/Todo.WebApi.csproj

$ dotnet add ./Core/Todo.Application/Todo.Application.csproj reference ./Core/Todo.Domain/Todo.Domain.csproj
$ dotnet add ./Infrastructure/Todo.Infrastructure/Todo.Infrastructure.csproj reference ./Core/Todo.Application/Todo.Application.csproj
$ dotnet add ./Presentation/Todo.WebApi/Todo.WebApi.csproj reference ./Infrastructure/Todo.Infrastructure/Todo.Infrastructure.csproj
```

## Nuget 패키지 추가
```bash
$ dotnet add ./Core/Todo.Application/Todo.Application.csproj package AutoMapper
$ dotnet add ./Core/Todo.Application/Todo.Application.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection
$ dotnet add ./Core/Todo.Application/Todo.Application.csproj package MediatR
$ dotnet add ./Core/Todo.Application/Todo.Application.csproj package MediatR.Extensions.Microsoft.DependencyInjection
$ dotnet add ./Core/Todo.Application/Todo.Application.csproj package FluentValidation
$ dotnet add ./Core/Todo.Application/Todo.Application.csproj package FluentValidation.DependencyInjectionExtensions
```
## Db Migrations
```bash
$ dotnet ef migrations add InitialCreate -p ./Infrastructure/Todo.Persistence/Todo.Persistence.csproj -s ./Presentation/Todo.WebApi/Todo.WebApi.csproj
$ dotnet ef database update -p ./Infrastructure/Todo.Persistence/Todo.Persistence.csproj -s ./Presentation/Todo.WebApi/Todo.WebApi.csproj
```