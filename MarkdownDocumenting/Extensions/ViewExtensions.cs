using MarkdownDocumenting.Areas.Docs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdownDocumenting.Extensions
{
    public static class ViewExtensions
    {
        public static string IsActive(this DocumentationItem item)
        {
            return item.Name.IsActive();
        }
        public static string IsActive(this string item)
        {
            var routeData = new HttpContextAccessor().HttpContext.GetRouteData();
            if (routeData == null || routeData.Values["file"]?.ToString() != item)
                return "";

            return "mdl-color-text--accent";
        }
    }
}
