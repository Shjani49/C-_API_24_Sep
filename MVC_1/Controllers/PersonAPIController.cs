using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{
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
        public ActionResult<object> GetAllPeople()
        {
            // This is what we are returning. It gets serialized as JSON if we return an object.
            return new
            {
                name = "John",
                age = 31,
                city = "New York"
            };

            /* public ActionResult<IEnumerable<string>> GetAllPeople()
             {
                 return new[]
                 {
                     "Hello",
                     "This",
                     "Is",
                     "A",
                     "Test",
                     "Data"
                 };*/


        }
    }
}
