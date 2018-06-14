using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Test.WebTokenAuth.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3", "value4", "value5" };
        }
    }
}
