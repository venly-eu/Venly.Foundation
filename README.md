# Venly.Foundation

A .NET 10 solution template built on **Clean Architecture**, **CQRS**, and **DDD** — powered by [Venly.Dispatch](https://www.nuget.org/packages/Venly.Dispatch).

Scaffold a fully structured, production-ready solution in one command.

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

---

## Installation

```bash
dotnet new install Venly.Foundation
```

## Usage

```bash
dotnet new venly-foundation -n MyProject
```

---

## Solution Structure
MyProject/
MyProject.API/            # Composition root, controllers, middleware
MyProject.Application/    # Commands, queries, handlers, pipeline behaviors
MyProject.Domain/         # Aggregates, value objects, domain events
MyProject.Infrastructure/ # EF Core, repositories, unit of work
Tests/
MyProject.Domain.Tests/
MyProject.Application.Tests/

---

## What's Included

- Clean Architecture layer separation with enforced dependency rules
- CQRS via [Venly.Dispatch](https://www.nuget.org/packages/Venly.Dispatch) with command and query pipeline behaviors
- DDD building blocks — `AggregateRoot`, `Entity`, `ValueObject`, `DomainEvent`
- Domain event dispatching via `UnitOfWork` post-save
- `Result<T>` type with `ErrorType` for clean error handling
- Base controller with automatic HTTP status code mapping
- Global exception handling middleware
- Example `Account` aggregate, command, query, and event handler

---

## License

MIT © [Venly](https://venly.eu)