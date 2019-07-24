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
        public static string IsActive(this DocumentationItem item, string activeClass = "active")
        {
            return item.Name.IsActive(activeClass);
        }
        public static string IsActive(this string item, string activeClass = "active")
        {
            var routeData = new HttpContextAccessor().HttpContext.GetRouteData();
            if (routeData == null || routeData.Values["file"]?.ToString() != item)
                return "";

            return activeClass;
        }
    }
}
