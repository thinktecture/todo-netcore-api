using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Thinktecture.Todo.Api.Models;
using WebPush;

namespace Thinktecture.Todo.Api.Services
{
    public class PushService
    {
        private readonly WebPushClient _webPushClient = new WebPushClient();
        private readonly List<PushSubscription> _subscriptions = new List<PushSubscription>();

        public PushService(IOptions<VapidKeys> vapidKeys)
        {
            _webPushClient.SetVapidDetails("mailto:office@thinktecture.com", vapidKeys.Value.Public, vapidKeys.Value.Private);
        }
        
        public void Register(PushSubscription subscription)
        {
            if (_subscriptions.All(s => s.Endpoint != subscription.Endpoint))
            {
                _subscriptions.Add(subscription);
            }
        }

        public void NotifyAll(object payload)
        {
            _subscriptions.ToList().ForEach(subscription => SendNotification(subscription, payload));
        }
        
        private void SendNotification(PushSubscription subscription, object payload)
        {
            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
             
                _webPushClient.SendNotification(subscription, JsonConvert.SerializeObject(payload, jsonSerializerSettings));
            }
            catch (Exception)
            {
                var index = _subscriptions.FindIndex(s => s.Endpoint == subscription.Endpoint);
                _subscriptions.RemoveAt(index);
            }
        }

        public void Clear()
        {
            _subscriptions.Clear();
        }
    }
}