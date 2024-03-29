﻿using MarkdownDocumenting.Elements;
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
        /// You can change the code colorer javascript. You can visit here: 'https://highlightjs.org/'.
        /// Default value is "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.13.1/styles/github-gist.min.css"
        /// </summary>
        public string HighlightJsStyle { get; set; } = "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.13.1/styles/github-gist.min.css";

        /// <summary>
        /// You can change your material design color if you're using default layout. Visit here to get: 'https://getmdl.io/customize/index.html'.
        /// Default value is "https://code.getmdl.io/1.3.0/material.indigo-pink.min.css".
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

        /// <summary>
        /// Prefix to be used for routing. If you have an Gateway that uses routes with route parameter for your APIs, you may use this.
        /// For Example, your root url is domain.com/myapi/  just set <see cref="RoutePrefix"/> as "myapi/". If not routing will be domain.com/Docs/readme, but after you set it will be domain.com/myapi/Docs/readme
        /// Default is 'null'
        /// </summary>
        public string RoutePrefix { get; set; }

        /// <summary>
        /// If this is true, root path ( "/" ) will be handled by MarkdownDocumenting and it'll display Docs/readme by default. If you set Redirect, all requests to root path ( "/" ) will be redirected to "/Docs" path.
        /// If you add any Action with [HttpGet("/")] attribute, your action will be executed while using HandleWithHighOrder. Default Order is <see cref="int.MaxValue"/>
        /// </summary>
        public HandlingType RootPathHandling { get; set; }

        /// <summary>
        /// Gets or sets navbar style.
        /// </summary>
        public NavBarStyle NavBarStyle { get; set; } = NavBarStyle.Default;
    }
}
