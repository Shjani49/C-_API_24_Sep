using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{

    // In Class Practice
    // #1: Add a Link to the Nav that points to the Input page.
    // #2: Research and implement a redirect from Index() to Input().
    // #3: Modify the output on the Output page to add some fun facts about the data inputted.
    // - First Letter of First Name
    // - First Letter of Last Name (Assume 2 word names)
    // - Length of First Name
    // - Length of Last Name
    // - Domain of Email (ex "example.com")
    // - Area code of phone number (Assume 1-###-234-3456 OR ###-456-9876)
    // #4: Null-coalesce the parameters of Output(). 


    public class FormExampleController : Controller
    {
        public IActionResult Index()
        {
            // return View();
            return RedirectToAction("Input");
        }

        public IActionResult Input()
        {
            return View();
        }

        public IActionResult Output(string name, string email, string phone )
        {
            ViewBag.Name = name??"No Name Provided";
            ViewBag.Email = email?? "No email Provided";
            ViewBag.Phone = phone?? "No phone Provided";


            return View();
        }
    }
}
 