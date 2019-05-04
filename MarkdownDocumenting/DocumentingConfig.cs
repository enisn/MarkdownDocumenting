using MarkdownDocumenting.Elements;
using MarkdownDocumenting.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdownDocumenting
{
    public class DocumentingConfig
    {
        public static DocumentingConfig Current { get; } = new DocumentingConfig();
        /// <summary>
        /// You can set your custom layout. Default is: "/Areas/Docs/Views/_Layout.cshtml"
        /// </summary>
        public string Layout { get; set; } = "/Areas/Docs/Views/_Layout.cshtml";
        /// <summary>
        /// You can change the code colorer javascript. You can visit here: https://highlightjs.org/
        /// </summary>
        public string HighlightJS { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.13.1/styles/github-gist.min.css";
        /// <summary>
        /// You can change your material design color if you're using default layout. Visit here to get: https://getmdl.io/customize/index.html
        /// </summary>
        public string GetMdlStyle { get; set; } = "https://code.getmdl.io/1.3.0/material.indigo-pink.min.css";
        /// <summary>
        /// This is Full Path of index document.
        /// </summary>
        public string IndexDocument { get; set; }
        /// <summary>
        /// Custom links to be shown end of menu drawer if you're using default layout.
        /// </summary>
        public List<CustomLink> CustomLinks { get; } = new List<CustomLink>();
        /// <summary>
        /// These will be displayed at bottom links
        /// </summary>
        public List<CustomLink> FooterMetaDatas { get; } = new List<CustomLink>();
    }
}
