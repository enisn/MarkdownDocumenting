using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdownDocumenting.Areas.Docs.Models
{
    public class DocumentationItem
    {
        public bool IsFolder { get; set; }
        public string Name { get; set; }
        public List<string> SubDocumentations { get; set; }
    }
}
