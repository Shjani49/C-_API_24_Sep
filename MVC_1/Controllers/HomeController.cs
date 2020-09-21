using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_1.Models;

namespace MVC_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // "return View()" will call the view that is associated with the path "baseurl.com/Controller/Action".
            // In this case baseurl.com/Home/Index or Views/Home/Index.cshtml.
            return View();
        }

        public IActionResult Privacy()
        {
            // In this case we call baseurl.com/Home/Privacy or Views/Home/Privacy.cshtml.
            return View();
        }

        // When we click our "Test Page" link in the menu, it calls:
        //      asp-controller="Home" asp-action="Test"
        // This means it will call the controller called "HomeController" (not just "Home"), and the action method called "Test()".
        public IActionResult Test()
        {
            // This will output to the "Output" tab, allowing for console-like debugging outputs in an MVC application.
             Debug.WriteLine("--------------------\nDEBUGGING OUTPUT: Test() Action Called!\n--------------------");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
