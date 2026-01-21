using System;
using MiniYoutube.Core.Enums;

namespace MiniYoutube.Core.Entities
{
    public class Like : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TargetId { get; set; }
        public LikeTargetType TargetType { get; set; }
    }
}
