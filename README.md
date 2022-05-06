### DotnetGeneratorEnumBugTest
## Steps taken when building this reproduction:
1. Create project with these configuration settings: ![config](https://github.com/MarcinKnyc/DotnetGeneratorEnumBugTest/blob/master/assets/project%20creation.png)
2. Add Model, Enum, DbContext, configure the database (see commit history)
```C#
    public class ContainsEnumProperty
    {
        [Key]
        public Guid Id { get; set; }
        public EnumType EnumType { get; set; }
    }
    public enum EnumType
    {
        Option1,
        Option2
    }    
```
3. Use Packet Manager Console to create the database
```
Each package is licensed to you by its owner. NuGet is not responsible for, nor does it grant any licenses to, third-party packages. Some packages may include dependencies which are governed by additional licenses. Follow the package source (feed) URL to determine any dependencies.

Package Manager Console Host Version 6.1.0.106

Type 'get-help NuGet' to see all available NuGet commands.

PM> git status
On branch master
Your branch is up to date with 'origin/master'.

nothing to commit, working tree clean
PM> Add-Migration firstMigration
Build started...
Build succeeded.
Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.4 initialized 'ApplicationDbContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.4' with options: None
To undo this action, use Remove-Migration.
PM> Update-Database
Build started...
Build succeeded.
Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.4 initialized 'ApplicationDbContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.4' with options: None
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (296ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [EnumTest];
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (66ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      IF SERVERPROPERTY('EngineEdition') <> 5
      BEGIN
          ALTER DATABASE [EnumTest] SET READ_COMMITTED_SNAPSHOT ON;
      END;
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (8ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (13ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [__EFMigrationsHistory] (
          [MigrationId] nvarchar(150) NOT NULL,
          [ProductVersion] nvarchar(32) NOT NULL,
          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (14ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (15ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20220506103456_firstMigration'.
Applying migration '20220506103456_firstMigration'.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Models] (
          [Id] uniqueidentifier NOT NULL,
          [EnumType] int NOT NULL,
          CONSTRAINT [PK_Models] PRIMARY KEY ([Id])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (20ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20220506103456_firstMigration', N'6.0.4');
Done.
PM> 
```
4. Scaffold the controller

![popup](https://github.com/MarcinKnyc/DotnetGeneratorEnumBugTest/blob/master/assets/add%20scaffolded%20item.png)
![option](https://github.com/MarcinKnyc/DotnetGeneratorEnumBugTest/blob/master/assets/mvc%20controller%20with%20views%20and%20entity%20framework.png)
![config](https://github.com/MarcinKnyc/DotnetGeneratorEnumBugTest/blob/master/assets/scaffolding%20configuration.png)

5. Here are the screens of the project at work. The last picture shows the bug.
 
![index](https://github.com/MarcinKnyc/DotnetGeneratorEnumBugTest/blob/master/assets/screen%201%20of%20working%20program.png)
![create](https://github.com/MarcinKnyc/DotnetGeneratorEnumBugTest/blob/master/assets/screen%202%20of%20working%20program.png)
![bug](https://github.com/MarcinKnyc/DotnetGeneratorEnumBugTest/blob/master/assets/screen%203%20of%20working%20program%20-%20the%20bug.png)
