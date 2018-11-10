using System;

namespace Thinktecture.Todo.Api.Models
{
    public class PushSubscriptionJson
    {
        public string Endpoint { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public PushSubscriptionJsonKeys Keys { get; set; }
    }

    public class PushSubscriptionJsonKeys
    {
        public string Auth { get; set; }
        public string P256DH { get; set; }
    }
}