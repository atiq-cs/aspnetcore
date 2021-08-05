##  Contoso University
Cloned from,
https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/ef-rp/intro/samples/cu50

Documentation,
https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro

Figure out the changes to make sql and sqlite work with EF.

As we can see, default env for our local run is `Production`.

json files don't allow comments hence it's here,

**ConnectionString for SQL Server**

    "SchoolContext": "Server=(localdb)\\mssqllocaldb;Database=CU-1;Trusted_Connection=True;MultipleActiveResultSets=true"

**ConnectionString for SQLite**

    "SchoolContext": "Data Source=CU.db"

### Config Files
Dev config file: `appsettings.Development.json`
Prod config file: `appsettings.json`
- Touching `appsettings1.json` seems to affect prod env.

Example run,

    $ $Env:ASPNETCORE_ENVIRONMENT = "Development"

    $ dotnet run
    info: Microsoft.Hosting.Lifetime[0]
        Now listening on: http://localhost:5000
    info: Microsoft.Hosting.Lifetime[0]
        Now listening on: https://localhost:5001
    info: Microsoft.Hosting.Lifetime[0]
        Application started. Press Ctrl+C to shut down.
    info: Microsoft.Hosting.Lifetime[0]
        Hosting environment: Production
    info: Microsoft.Hosting.Lifetime[0]
        Content root path: D:\git_ws\aspnetcore\cu50
    info: Microsoft.Hosting.Lifetime[0]
        Application is shutting down...

### VS Pro SQL Data Explorer
Server:

    (localdb)\MSSQLLocalDB
