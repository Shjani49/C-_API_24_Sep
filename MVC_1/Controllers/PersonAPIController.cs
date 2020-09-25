using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;
using MVC_1.Models.Exceptions;

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
            /* // This is what we are returning. It gets serialized as JSON if we return an object.
             Person person = new PersonController().GetPersonByID(id);

             // This is "kind of" a DTO. We're putting the fields we care about into another object that is not the database model.
             // They help get around errors like the circular references, and (if you use them in the context) the missing virtual properties.
             return new
             {
                 id = person.ID,
                 firstName = person.FirstName,
                 lastName = person.LastName,
                 phoneNumbers = person.PhoneNumbers.Select(x => x.Number)
             };*/
            ActionResult<object> response;
            try
            {
                Person person = new PersonController().GetPersonByID(id);

                // This is "kind of" a DTO. We're putting the fields we care about into another object that is not the database model.
                // They help get around errors like the circular references, and (if you use them in the context) the missing virtual properties.
                response = new
                {
                    id = person.ID,
                    firstName = person.FirstName,
                    lastName = person.LastName,
                    phoneNumbers = person.PhoneNumbers.Select(x => x.Number)
                };
            }
            catch
            {
                response = NotFound(new { error = $"No person at ID {id} could be found." });
            }

            return response;
        }

        // This method of GET parameters will retrieve the argument from the query string (after the ? in the URL).
        [HttpGet("People/ID")]
        public ActionResult<object> GetPersonWithIDParameterized(int id)
        {
            /* // This is what we are returning. It gets serialized as JSON if we return an object.
             Person person = new PersonController().GetPersonByID(id);

             // This is "kind of" a DTO. We're putting the fields we care about into another object that is not the database model.
             // They help get around errors like the circular references, and (if you use them in the context) the missing virtual properties.
             return new
             {
                 id = person.ID,
                 firstName = person.FirstName,
                 lastName = person.LastName,
                 phoneNumbers = person.PhoneNumbers.Select(x => x.Number)
             */
            ActionResult<object> response;
            // This is what we are returning. It gets serialized as JSON if we return an object.
            try
            {
                Person person = new PersonController().GetPersonByID(id);

                // This is "kind of" a DTO. We're putting the fields we care about into another object that is not the database model.
                // They help get around errors like the circular references, and (if you use them in the context) the missing virtual properties.
                response = new
                {
                    id = person.ID,
                    firstName = person.FirstName,
                    lastName = person.LastName,
                    phoneNumbers = person.PhoneNumbers.Select(x => x.Number)
                };
            }
            catch
            {
                response = NotFound(new { error = $"No person at ID {id} could be found." });
            }

            return response;
        }


        // Patches can either be in this format below, where an endpoint does one action, or in a format that specifies the "instructions" in the query.
        /*
         For example:
         id: 9,
         action: update,
         variable: FirstName,
         value: John
        or
          id: 20,
          action: add,
          variable: Count,
          value: 5
        */
        [HttpPatch("People/FirstName")]
        public ActionResult ChangeFirstName(int id, string newName)
        {
            ActionResult response;
            try
            {
                new PersonController().ChangeFirstNameByID(id, newName);
              
                response = Ok(new { message = $"Successfully renamed person {id} to {newName}." });
            }
        
            catch (InvalidOperationException)
            {
                response = NotFound(new { error = $"The requested person at ID {id} does not exist." });
            }
            catch (Exception e)
            {
                response = Conflict(new { error = e.Message });
            }


            return response;
        }

        [HttpPost("People/Create")]
        public ActionResult CreatePerson(string firstName, string lastName, string phone)
        {
            ActionResult response;
            try
            {
                int newID = new PersonController().CreatePerson(firstName, lastName, phone);

                // Just for fun:
                // (It's also an example of how to throw a code that doesn't have a method built-in)
                if (firstName.Trim().ToUpper() == "TEAPOT" && lastName.Trim().ToUpper() == "COFFEE")
                {
                    response = StatusCode(418, new { message = $"Successfully created teapot but it does not want to brew coffee. It has the phone number {phone}." });
                }
                else
                {
                    // This should really be a Create() that provides the API endpoint for the GET to retrieve the created object.
                    response = Created($"API/PersonAPI/People/ID/{newID}", new { message = $"Successfully created person {firstName} {lastName} with the phone number {phone} at ID {newID}." });
                }
            }
            catch (PersonValidationException e)
            {
                response = UnprocessableEntity(new { errors = e.SubExceptions.Select(x => x.Message) });
            }


            return response;
        }

       
        [HttpDelete("People/Delete")]
        public ActionResult DeletePerson(string id)
        {
            ActionResult response;

            // This logic should probably be in the DeletePersonByID() method, but if I change the parameter type to string now, I'll have to fix compiler errors in the Views.
            int idParsed;
            if (string.IsNullOrWhiteSpace(id))
            {
                response = Conflict(new { error = "ID was not provided." });
            }
            else
            {
                if (!int.TryParse(id, out idParsed))
                {
                    response = Conflict(new { error = "The provided ID is invalid." });
                }
                else
                {
                    try
                    {
                        new PersonController().DeletePersonByID(idParsed);
                        response = Ok(new { message = $"Successfully deleted the person with ID {idParsed}." });
                    }
                    catch
                    {
                        response = NotFound(new { error = $"No person at ID {idParsed} could be found." });
                    }
                }
            }
            return response;
        }
    }
}

