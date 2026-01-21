using System;

namespace MiniYoutube.Core.Entities
{
    public class WatchHistory : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid VideoId { get; set; }
        public int WatchDurationSeconds { get; set; }
        public DateTime LastWatchedAt { get; set; }
    }
}
