##  Contoso University
Cloned from
[dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/ef-rp/intro/samples/cu50](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/ef-rp/intro/samples/cu50)

Documentation is at [MS Docs aspnet/core/data/ef-rp/intro](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro)

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

Verbose Example At [SqLite-Run Example wikipage](SqLite-Run.md)
