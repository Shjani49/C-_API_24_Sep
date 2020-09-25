using Microsoft.AspNetCore.Mvc;
using MVC_1.Models.Exceptions;


namespace MVC_1.Controllers
{
    public partial class PersonController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        // id is not necessary as it is now AUTO_INCREMENT in the database, and is generated thereby.
        public IActionResult Create(string firstName, string lastName, string phone)
        {
            // When this Action gets called, there are 3 likely states:
            // 1) First page load, no data has been provided (initial state).
            // 2) Partial data has been provided (error state).
            // 3) Complete data has been provided (submit state).

            // A request has come in that has some data stored in the query (GET or POST).

            if (Request.Query.Count > 0)
            {
                try
                {
                    CreatePerson(firstName, lastName, phone);

                    ViewBag.Success = "Successfully added the person to the list.";
                }
                catch (PersonValidationException e)
                {
                    // All expected data not provided, so this will be our error state.
                    ViewBag.Exception = e;

                    // Store our data to re-add to the form.
                    ViewBag.FirstName = firstName != null ? firstName.Trim() : null;
                    ViewBag.LastName = lastName != null ? lastName.Trim() : null;
                    ViewBag.Phone = phone != null ? phone.Trim() : null;
                }
            }

            return View();
        }
        public IActionResult List(string filter)
        {

            // Slightly different from practice as you'll be calling methods and not using a "using" in your action.
            if (filter == "on")
            {
                ViewBag.People = GetPeopleWithMultiplePhoneNumbers();
                ViewBag.Filter = filter;
            }
            else
            {
                ViewBag.People = GetPeople();
            }



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
    }
}