# NotBook

## Local Setup

Prerequisites:

- .NET 10 SDK
- SQL Server LocalDB

From the solution root, restore and build the solution:

```powershell
dotnet restore NotBook.Solution.slnx
dotnet build NotBook.Solution.slnx --no-restore
```

Run the API:

```powershell
dotnet run --project NotBook.APIs --launch-profile http
```

The development API listens on `http://localhost:5205`.

### Apply migrations on a new machine

The application and EF Core design-time factory use LocalDB database
`NotBookDB`. From the solution root, apply all migrations with:

```powershell
dotnet ef database update --project NotBook.Repository --startup-project NotBook.APIs
```
