# cms-localization
Multi-language content management system, .Net Core CRUD project. Thanks to ILocalizedModel, dynamically content can be saved in different languages.

## Pre-requisites

1. [.Net core 2.2 SDK](https://www.microsoft.com/net/core#windows)
2. [Visual studio 2017](https://www.visualstudio.com/) OR [VSCode](https://code.visualstudio.com/) with [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) extension
3. [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2017) (Optional: If MS SQL server required instead of Sqlite during development)

## Installation
```
1. Clone the repo:
    git clone https://github.com/bernalbant/cms-localization.git
2. Restore packages:
    dotnet restore CmsLocalization.sln
3. Add Migration
    dotnet ef migrations add InitialMigration
    dotnet ef database update
4. Run .Net project:
    F5 from either [Visual Studio IDE](https://www.visualstudio.com/) OR [VScode] (https://code.visualstudio.com/):
```
