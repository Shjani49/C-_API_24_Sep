using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;

namespace MVC_1.Controllers
{
    // In-Class Practice: 
    // Add a PersonController method to get all people whose name starts with J.
    // Add an API endpoint that will return the results of that method to "People/NamesStartingJ".

    // Challenge:
    // Modify the PersonController method to accept a character.
    // Make the API endpoint respond to all possible starting characters at "People/StartsWith/{char}"
    // Add and API endpoint at "People/ID/{id}" that will return only the person with that ID.

    // In-Class Practice Part 2:
    // Add a second endpoint for the "name starts with" that uses the query string and not the URL.


    // GET: Read / Query - Get some data.
    // POST: Create - Add some data.
    // PUT: Update (Overwrite) - Replace some data.
    // PATCH: Update (Modify) - Modify some data.
    // DELETE: Delete - Remove some data.


    // Common Status Codes:
    // 200: Ok - Everything's good.
    // 400: Bad Request - Invalid data types / syntax / etc.
    // 404: Not Found - No item with that ID, etc exists.
    // 409: Conflict - Breaks a business logic rule, etc.

    // Given:
    // [Route("API/[controller]") and [HttpGet("People/Test")]
    // Our path should be: https://localhost:PORT/API/PersonAPI/People/Test

    // This determines the first segment of the path. 
    [Route("API/[controller]")]
    // This defines the controller as an API controller.
    [ApiController]
    // Our class name (sans 'Controller') is substituted into [controller] in the Route annotation.
    public class PersonAPIController : ControllerBase
    {
        // This determines the second segment of the path.
        [HttpGet("People/All")]

        // This is the return type of the request. The method name is irrelevant as far as the clients are concerned.
        public ActionResult<IEnumerable<Person>> GetAllPeople()
        {
            PersonController controller = new PersonController();
            return controller.GetPeople();
        }

        // This determines the second segment of the path.
        [HttpGet("People/MultiplePhones")]

        // This is the return type of the request. The method name is irrelevant as far as the clients are concerned.
        public ActionResult<IEnumerable<Person>> GetPeopleWithMultiplePhones()
        {
            // This is what we are returning. It gets serialized as JSON if we return an object.
            PersonController controller = new PersonController();
            return controller.GetPeopleWithMultiplePhoneNumbers();


        }

        // This determines the second segment of the path.
        [HttpGet("People/StartsWith/{startChar:alpha}")]

        // This is the return type of the request. The method name is irrelevant as far as the clients are concerned.
        public ActionResult<IEnumerable<Person>> GetPeopleWhoseNamesStartWith(string startChar)
        {
            // Assuming we aren't using the controller again, we might as well just instantiate it where we need it the one time.
            return new PersonController().GetPeopleStartingWith(startChar);
        }

        // This determines the second segment of the path.
        [HttpGet("People/StartsWith")]

        // This is the return type of the request. The method name is irrelevant as far as the clients are concerned.
        public ActionResult<IEnumerable<Person>> GetPeopleWhoseNamesStartWithparameterized(string startChar)
        {
            // Assuming we aren't using the controller again, we might as well just instantiate it where we need it the one time.
            return new PersonController().GetPeopleStartingWith(startChar);
        }



        // This determines the second segment of the path.
        //  [HttpGet("People/ID/{ID}")]

        // This method of GET parameters will retrieve the argument from the URL.
        [HttpGet("People/ID/{id}")]

        // This is the return type of the request. The method name is irrelevant as far as the clients are concerned.
        public ActionResult<object> GetPersonWithID(int id)
        {
            // This is what we are returning. It gets serialized as JSON if we return an object.
            Person person = new PersonController().GetPersonByID(id);

            // This is "kind of" a DTO. We're putting the fields we care about into another object that is not the database model.
            // They help get around errors like the circular references, and (if you use them in the context) the missing virtual properties.
            return new
            {
                id = person.ID,
                firstName = person.FirstName,
                lastName = person.LastName,
                phoneNumbers = person.PhoneNumbers.Select(x => x.Number)
            };
        }

        // This method of GET parameters will retrieve the argument from the query string (after the ? in the URL).
        [HttpGet("People/ID")]
        public ActionResult<object> GetPersonWithIDParameterized(int id)
        {
            // This is what we are returning. It gets serialized as JSON if we return an object.
            Person person = new PersonController().GetPersonByID(id);

            // This is "kind of" a DTO. We're putting the fields we care about into another object that is not the database model.
            // They help get around errors like the circular references, and (if you use them in the context) the missing virtual properties.
            return new
            {
                id = person.ID,
                firstName = person.FirstName,
                lastName = person.LastName,
                phoneNumbers = person.PhoneNumbers.Select(x => x.Number)
            };
        }

        [HttpPatch("People/FirstName")]
        public ActionResult ChangeFirstName(int id, string newName)
        {
            ActionResult response;
            try
            {
                new PersonController().ChangeFirstNameByID(id, newName);
                response = Ok(new { message = $"Successfully renamed person {id} to {newName}." });
            }
            catch (InvalidOperationException e)
            {
                response = NotFound(new { error = $"The requested person at ID {id} does not exist." });
            }
            catch (Exception e)
            {
                response = Conflict(new { error = e.Message });
            }

            return response;
        }
    }
}
