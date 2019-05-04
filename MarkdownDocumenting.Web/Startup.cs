using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkdownDocumenting.Areas.Docs.Controllers;
using MarkdownDocumenting.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MarkdownDocumenting.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDocumentation();

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseDocumentation(builder =>
            {
                builder.SetIndexDocument("Welcome.md");

                
                builder.Layout = "/Shared/_Layout";
                builder.HighlightJS = "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.13.1/styles/vs2015.min.css";   
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
