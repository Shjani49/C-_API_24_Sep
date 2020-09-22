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
        // In Class Practice 2:
        // Write a List View that will output the names of all the people in the AppPeople list.

        // Use a cached list to store the data without a database.
        // The data will not persist when the app closes.
        // It must be static to persist through page loads.
        static public List<Person> AppPeople { get; set; } = new List<Person>();

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult Create(string id, string firstName, string lastName, string phone)
        {
            // When this Action gets called, there are 3 likely states:
            // 1) First page load, no data has been provided (initial state).
            // 2) Partial data has been provided (error state).
            // 3) Complete data has been provided (submit state).

            // A request has come in that has some data stored in the query (GET or POST).
            if (Request.Query.Count > 0)
            {
                if (id != null && firstName != null && lastName != null && phone != null)
                {
                    // All expected data provided, so this will be our submit state.
                    Person newPerson = new Person()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };
                    PhoneNumber newPhoneNumber = new PhoneNumber()
                    {
                        Number = phone,
                        Person = newPerson
                    };
                    ViewBag.Success = "Successfully added the person to the list.";

                }
                else
                {
                    // All expected data not provided, so this will be our error state.
                    ViewBag.Error = "Not all fields have had values provided.";

                    // Store our data to re-add to the form.
                  
                    ViewBag.FirstName = firstName;
                    ViewBag.LastName = lastName;
                    ViewBag.Phone = phone;
                }
            }
            // else
            // No request, so this will be our inital state.

            return View();
        }

        public IActionResult List()
        {
            ViewBag.People = AppPeople;
            return View();
        }

        public IActionResult Details(string id, string delete)
        {
            IActionResult result;
            if (delete != null)
            {
                DeletePersonByID(int.Parse(id));
                result = RedirectToAction("List");
            }
            else
            {
                ViewBag.Person = GetPersonByID(int.Parse(id));
                result = View();
            }

            return result;
        }
        public Person GetPersonByID(int id)
        {
            return AppPeople.Where(x => x.ID == id).Single();
        }

        public void DeletePersonByID(int id)
        {
            AppPeople.Remove(AppPeople.Where(x => x.ID == id).Single());


        }
    }
}