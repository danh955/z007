# Blazor server template

This is a Blazor server web application template.  Use this to start a Blazor project.

### Using

- [Visual Studio v16.8](https://visualstudio.microsoft.com/vs/preview)
- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Tailwind CSS](https://www.tailwindcss.com)

### NuGet

- [SQLite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite) or [SQL Server](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)
- [MediatR](https://www.nuget.org/packages/MediatR/)
- [Serilog.AspNetCore](https://www.nuget.org/packages/Serilog.AspNetCore)
- [StyleCop.Analyzers](https://www.nuget.org/packages/StyleCop.Analyzers)
- [Microsoft.CodeAnalysis.FxCopAnalyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers)

### Visual Sudio Settings

- Tools > Options > Text Editor > C# > Advanced > Place 'System' directives first when sorting using = Checked.

### Visual Studio Extensions

- [CodeMaid](https://marketplace.visualstudio.com/items?itemName=SteveCadwallader.CodeMaid)
- [Visual Studio Spell Checker (VS2017 and Later)](https://marketplace.visualstudio.com/items?itemName=EWoodruff.VisualStudioSpellCheckerVS2017andLater)

### NPM

- Install [Node.js](https://nodejs.org)
- Run "npm install" inside the BlazorUI project.
- Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

### Task Runner Explorer

- View > Other Windows > Task Runner Explorer
- To create the development version of the wwwroot/site.css file, right click "css:dev" > Run
  - Create the full size css file for development.  Over 2MB.
- To create the production version of the wwwroot/site.css file, right click "css:prod" > Run
  - This will minify to a real small css file.
- The "watch" in task runner will start when the project is opened.  It will automatically update
  the wwwroot/site.css from the Styles/site.css and tailwind.config.js files during development.

### Vertical Slices Architecture

- [Vertical Slice Architecture - Jimmy Bogard](https://www.youtube.com/watch?v=SUiWfhAhgQw&lc=UgxKn5DIimiDXq1MWqB4AaABAg) (video)
- [SOLID Architecture in Slices not Layers by Jimmy Bogard](https://www.youtube.com/watch?v=wTd-VcJCs_M) (video)
- [Encountering "Vertical Slice Architecture" ... Is it incompatible with Clean Architecture?](https://jeremiahflaga.github.io/2019/05/20/vertical-slice-architecture-is-it-incompatible-with-clean-architecture)
- [Blazor - Where to put your domain logic](https://jonhilton.net/blazor-architecture/)
- [NDC talk on SOLID in slices not layers video online](https://lostechies.com/jimmybogard/2015/07/02/ndc-talk-on-solid-in-slices-not-layers-video-online)

### Article

- Integrating Tailwind CSS with Blazor using Gulp -[ Part 1](https://chrissainty.com/integrating-tailwind-css-with-blazor-using-gulp-part-1)
  and [Part 2](https://chrissainty.com/integrating-tailwind-css-with-blazor-using-gulp-part-2)
- [How to use Gulp in Visual Studio](https://www.davepaquette.com/archive/2014/10/08/how-to-use-gulp-in-visual-studio.aspx)

### Entity Framework Core

- NuGet package Microsoft.EntityFrameworkCore.Tools
- NuGet package Microsoft.EntityFrameworkCore.{SqlServer, SqLite, ...}
- Add-Migration InitialCreate
- Update-Database -Context "Core.Model.CoreDbContext"
