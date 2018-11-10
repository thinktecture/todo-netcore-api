using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Thinktecture.Todo.Api.Services;

namespace Thinktecture.Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private readonly SyncService _syncService;
        
        public SyncController(SyncService syncService)
        {
            _syncService = syncService;
            syncService.ResetItems();
        }

        // POST
        [HttpPost]
        public IActionResult Index([FromBody] List<Models.Todo> items)
        {
            return Ok(_syncService.Sync(items));
        }

        // GET clear
        [HttpGet("clear")]
        public IActionResult Clear()
        {
            _syncService.ResetItems();
           
            return Ok(JsonConvert.SerializeObject("Items cleared!"));
        }
    }
}