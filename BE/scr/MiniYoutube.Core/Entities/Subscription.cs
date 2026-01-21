using System;

namespace MiniYoutube.Core.Entities
{
    // Constraint: (subscriber_id, channel_id) UNIQUE
    public class Subscription : BaseEntity
    {
        public Guid SubscriberId { get; set; }
        public Guid ChannelId { get; set; }
    }
}
