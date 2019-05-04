using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdownDocumenting.Elements
{

    public class CustomLink
    {
        public CustomLink()
        {
        }

        public CustomLink(string display, string url, bool openInNewWindow = false)
        {
            Display = display;
            Url = url;
        }

        public string Display { get; set; }
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }
    }
}
