using Microsoft.AspNetCore.Mvc;

namespace Thinktecture.Todo.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class RootController : ControllerBase
    {
        // GET
        public IActionResult Index()
        {
            return Ok(@"""API is up and running.""");
        }
    }
}