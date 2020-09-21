using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;

namespace MVC_1.Controllers
{
    public class PersonController : Controller
    {
        // Use a cached list to store the data without a database.
        // The data will not persist when the app closes.
        // It must be static to persist through page loads.
        static public List<Person> AppPeople { get; set; } = new List<Person>();

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult Create(string name, string email, string phone)
        {
            // When this Action gets called, there are 3 likely states:
            // 1) First page load, no data has been provided (initial state).
            // 2) Partial data has been provided (error state).
            // 3) Complete data has been provided (submit state).

            // A request has come in that has some data stored in the query (GET or POST).
            if (Request.Query.Count > 0)
            {
                if (name != null && email != null && phone != null)
                {
                    // All expected data provided, so this will be our submit state.
                    AppPeople.Add(new Person()
                    {
                        Name = name,
                        Email = email,
                        Phone = phone
                    });

                    ViewBag.Success = "Successfully added the person to the list.";

                }
                else
                {
                    // All expected data not provided, so this will be our error state.
                    ViewBag.Error = "Not all fields have had values provided.";

                    // Store our data to re-add to the form.
                    ViewBag.Name = name;
                    ViewBag.Email = email;
                    ViewBag.Phone = phone;
                }
            }
            // else
            // No request, so this will be our inital state.

            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}