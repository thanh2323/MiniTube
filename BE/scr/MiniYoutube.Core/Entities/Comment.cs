using System;

namespace MiniYoutube.Core.Entities
{
    public class Comment : BaseEntity
    {
        public Guid VideoId { get; set; }
        public Guid UserId { get; set; }
        public Guid? ParentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public long LikeCount { get; set; }
    }
}
