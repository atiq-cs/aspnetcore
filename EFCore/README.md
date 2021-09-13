## EFCore Template from Sporty App
Extracts minimalist version from
[dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/ef-rp/intro/samples/cu50](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/ef-rp/intro/samples/cu50)

Documentation is at [MS Docs aspnet/core/data/ef-rp/intro](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro)

- Only supports SQL Server, SQLite version is removed
- Update Database name in `appsettings.Development.json` before running


As we can see, default env for our local run is `Production`.

json files don't allow comments hence it's here,

**ConnectionString for SQL Server**

    "SchoolContext": "Server=(localdb)\\mssqllocaldb;Database=Sporty-1;Trusted_Connection=True;MultipleActiveResultSets=true"


### Config Files
Dev config file: `appsettings.Development.json`
Prod config file: `appsettings.json`

Example run,

    $ $Env:ASPNETCORE_ENVIRONMENT = "Development"
    $ dotnet run

### Recreating the project
Create razor app,

    dotnet new webapp -n Sporty

Add required nuget packages,

    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
