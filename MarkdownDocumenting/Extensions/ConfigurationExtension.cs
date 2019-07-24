using Markdig;
using Markdig.Extensions.AutoIdentifiers;
using Markdig.Extensions.Tables;
using MarkdownDocumenting.Elements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Westwind.AspNetCore.Markdown;

namespace MarkdownDocumenting.Extensions
{

    public static class ConfigurationExtension
    {
        [Obsolete("USe builder instead of this. See documentation for more information")]
        public static IApplicationBuilder AddCustomLink(this IApplicationBuilder app, CustomLink item)
        {
            DocumentingConfig.Current.CustomLinks.Add(item);
            return app;
        }
        public static DocumentingConfig AddCustomLink(this DocumentingConfig config, CustomLink item)
        {
            config.CustomLinks.Add(item);
            return config;
        }
        public static DocumentingConfig AddFooterLink(this DocumentingConfig config, CustomLink item)
        {
            config.FooterMetaDatas.Add(item);
            return config;
        }
        public static DocumentingConfig SetIndexDocument(this DocumentingConfig config, string markdownFile)
        {
            config.IndexDocument = markdownFile;
            return config;
        }
        public static IApplicationBuilder UseDocumentation(this IApplicationBuilder app, Action<DocumentingConfig> configAction = default)
        {
            if (configAction != default)
                configAction(DocumentingConfig.Current);

            if (DocumentingConfig.Current.RootPathHandling == HandlingType.Redirect)
            {
                app.Use(AddRootRedirection);
            }

            return app;
        }

        private static Task AddRootRedirection(HttpContext ctx, Func<Task> next)
        {
            if (ctx.Request.Path.Value == "/")
	        {
                ctx.Response.Redirect($"/{DocumentingConfig.Current.RoutePrefix}Docs/");
                return Task.CompletedTask;
	        }
            return next();
        }

        public static IServiceCollection AddDocumentation(this IServiceCollection services, Action<MarkdownPipelineBuilder> markdownPipelineBuilder = default, bool addHttpContextAccessor = true)
        {
            if (addHttpContextAccessor)
                services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            if (markdownPipelineBuilder == default)
                markdownPipelineBuilder = builder =>
                {
                    builder.UseEmphasisExtras(Markdig.Extensions.EmphasisExtras.EmphasisExtraOptions.Default)
                        .UsePipeTables(new PipeTableOptions
                        {
                            RequireHeaderSeparator = true
                        })
                        .UseGridTables()
                        .UseAutoIdentifiers(AutoIdentifierOptions.AutoLink)
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

            services.AddMarkdown(config =>
            {
                config.ConfigureMarkdigPipeline = markdownPipelineBuilder;
            });
            return services;
        }

    }
}
