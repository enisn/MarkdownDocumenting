using Markdig;
using Markdig.Extensions.AutoIdentifiers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Westwind.AspNetCore.Markdown;

namespace MarkdownDocumenting.Extensions
{

    public static class ConfigurationExtension
    {
        public static IApplicationBuilder AddCustomLink(this IApplicationBuilder app, CustomLink item)
        {
            Configuration.CustomLinks.Add(item);
            return app;
        }
        public static IApplicationBuilder UseDocumentation(this IApplicationBuilder app, CustomLink item)
        {
            return app;
        }
        public static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMarkdown(config =>
            {
                config.ConfigureMarkdigPipeline = builder =>
                {
                    builder.UseEmphasisExtras(Markdig.Extensions.EmphasisExtras.EmphasisExtraOptions.Default)
                        .UsePipeTables()
                        .UseGridTables()
                        .UseAutoIdentifiers(AutoIdentifierOptions.GitHub) 
                        .UseAutoLinks() 
                        .UseAbbreviations()
                        .UseYamlFrontMatter()
                        .UseEmojiAndSmiley(true)
                        .UseListExtras()
                        .UseFigures()
                        .UseTaskLists()
                        .UseCustomContainers()
                        .UseGenericAttributes();
                };
            });
            return services;
        } 
    }



    public class CustomLink
    {
        public CustomLink()
        {
        }

        public CustomLink(string display, string url)
        {
            Display = display;
            Url = url;
        }

        public string Display { get; set; }
        public string Url { get; set; }
    }

}
