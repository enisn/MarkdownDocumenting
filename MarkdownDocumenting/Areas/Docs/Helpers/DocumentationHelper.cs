using MarkdownDocumenting.Areas.Docs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MarkdownDocumenting.Areas.Docs.Helpers
{
    public class DocumentationHelper
    {
        static string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Docs");
        public static IEnumerable<DocumentationItem> GetMenu()
        {

            foreach (var folder in Directory.GetDirectories(path))
            {
                yield return new DocumentationItem
                {
                    IsFolder = true,
                    Name = GetFriendlyName(folder),
                    SubDocumentations = Directory.GetFiles(Path.Combine(path, folder)).Where(x => x.EndsWith(".md")).Select(GetFriendlyName).ToList(),
                };
            }

            foreach (var doc in Directory.EnumerateFiles(path).Where(x => x.EndsWith(".md")))
            {
                yield return new DocumentationItem
                {
                    IsFolder = false,
                    Name = GetFriendlyName(doc)
                };
            }
        }

        public static string GetContent(string nameWithoutExtension)
        {
            try
            {
                return File.ReadAllText(Path.Combine(path, nameWithoutExtension + ".md"));
            }
            catch (Exception)
            {
                return null;
            }
        }

        static string GetFriendlyName(string value)
        {
            //if (withFolder)
            //    return "";

            return Path.GetFileNameWithoutExtension(value);
        }
    }
}
