# Auto-Documentation

>AspNetCore.MarkdownDocumenting

This project provides markdown documentation for your .net core projects automaticly.


<hr />

# Hot does it work ?

It's easy. Just place your markdown documents under Docs folder and go **/Docs** path in your project.

<table> 
<tr>
<td><img width="360" src="https://github.com/enisn/MarkdownDocumenting/blob/master/images/screen_01.PNG?raw=true" alt="AspNet Core Markdown Documentation" /> </td>
<td> <img width="360" src="https://github.com/enisn/MarkdownDocumenting/blob/master/images/screen_00.PNG?raw=true" alt="AspNet Core Markdown Documentation"> </td>
</tr>
</table>


<hr />

# How to start using ?

- Install NuGet package.

- Create a folder into your project root which name is `Docs`. And put your **Markdown** files under it. You can use Sub Folders to group them.

- You must set your **.md** files `Copy To Output Directory` as `Copy Always`. *To do this. Right click the markdown file and go Properties, then you'll see that option. Just change it.*

- Go to `Startup.cs` and add following coe to your ConfigureServices method:
    
```csharp

        public void ConfigureServices(IServiceCollection services)
        {
            //...
            services.AddDocumentation(); // < --- add this into startup.cs
            //...
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
        }

```

<hr />

### Optional Configurations:

- Use `AddCustomLink();` to add menu items into Configure() method in Startup.cs.

 Example:

```csharp

        app.AddCustomLink(new CustomLink("Home","https://www.google.com"));

```

- To Change Layout:

```csharp
            MarkdownDocumenting.Configuration.Layout = "/Views/Shared/_Layout";

```
- To Change Highlight.js theme:

```csharp
            MarkdownDocumenting.Configuration.HighlightJS = "http://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.13.1/styles/vs2015.min.css";
```

