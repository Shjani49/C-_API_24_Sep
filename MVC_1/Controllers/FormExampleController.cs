using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{
    public class FormExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Input()
        {
            return View();
        }

        public IActionResult Output(string name, string email, string phone)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Phone = phone;

            return View();
        }
    }
}
