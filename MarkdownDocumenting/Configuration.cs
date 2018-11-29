using MarkdownDocumenting.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdownDocumenting
{
    public class Configuration
    {
        public static string Layout { get; set; } = "/Areas/Docs/Views/_Layout.cshtml";
        public static string HighlightJS { get; set; } = "http://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.13.1/styles/github-gist.min.css";
        public static string GetMdlStyle { get; set; } = "https://code.getmdl.io/1.3.0/material.indigo-pink.min.css";

        public static List<CustomLink> CustomLinks { get; set; } = new List<CustomLink>();
    }
}
