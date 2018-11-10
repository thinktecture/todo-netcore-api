using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Thinktecture.Todo.Api.Models;
using Thinktecture.Todo.Api.Services;
using WebPush;

namespace Thinktecture.Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushController : ControllerBase
    {
        private readonly PushService _pushService;
        
        public PushController(PushService pushService)
        {
            _pushService = pushService;
        }
        
        // POST register
        [HttpPost("register")]
        public IActionResult Register([FromBody] PushSubscriptionJson subscription)
        {
            _pushService.Register(new PushSubscription(subscription.Endpoint, subscription.Keys.P256DH, subscription.Keys.Auth));
            
            return Ok(JsonConvert.SerializeObject("ok"));
        }

        // POST notifyAll
        [HttpPost("notifyAll")]
        public IActionResult NotifyAll([FromBody] PushNotification notification)
        {
            var payload = new {
                Notification = new {
                    notification.Title,
                    notification.Body,
                    Icon = "/assets/icon-144x144.png"
                }
            };
            
            _pushService.NotifyAll(payload);

            return Ok();
        }

        // GET clear
        [HttpGet("clear")]
        public IActionResult Clear()
        {
            _pushService.Clear();
            
            return Ok(JsonConvert.SerializeObject("Subscriptions cleared"));
        }
    }
}