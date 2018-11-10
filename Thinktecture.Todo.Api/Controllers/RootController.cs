using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Thinktecture.Todo.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class RootController : ControllerBase
    {
        // GET
        public IActionResult Index()
        {
            return Ok(JsonConvert.SerializeObject("API is up and running."));
        }
    }
}