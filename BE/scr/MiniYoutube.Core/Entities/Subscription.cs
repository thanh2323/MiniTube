using System;

namespace MiniYoutube.Core.Entities
{
    public class Subscription : BaseEntity
    {
        public Guid SubscriberId { get; set; }
        public Guid ChannelId { get; set; }
    }
}
