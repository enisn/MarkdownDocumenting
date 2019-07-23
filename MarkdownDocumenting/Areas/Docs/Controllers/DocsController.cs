using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkdownDocumenting.Areas.Docs.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace MarkdownDocumenting.Areas.Docs.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DocsController : Controller
    {
        const string VIEW_INDEX = "/Areas/Docs/Views/Docs/Index.cshtml";

        [HttpGet("/")]
        [HttpGet("/Docs")]
        public IActionResult Index()
        {
            ViewData["Title"] = DocumentingConfig.Current.IndexDocument ?? "README";
            return View(VIEW_INDEX, DocumentingConfig.Current.IndexDocument ?? DocumentationHelper.GetContent("README") ?? DocumentationHelper.GetContent("readme"));
        }
        [HttpGet("{folder}/{file}")]
        public IActionResult Index(string folder, string file)
        {
            ViewData["Title"] = file;
            return View(VIEW_INDEX, DocumentationHelper.GetContent(folder + "/" + file));
        }

        [HttpGet("{file}")]
        public IActionResult RootDoc(string file)
        {
            ViewData["Title"] = file;
            return View(VIEW_INDEX, DocumentationHelper.GetContent(file) ?? DocumentationHelper.GetContent(file + "/README") ?? DocumentationHelper.GetContent(file + "/readme"));
        }
    }
}
