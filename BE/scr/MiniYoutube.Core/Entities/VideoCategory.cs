using System;

namespace MiniYoutube.Core.Entities
{
    // Join entity, doesn't necessarily need BaseEntity but good for consistency if we want tracking
    // However, usually join tables have composite keys.
    // For simplicity and "clean architecture" entities, we'll just have the properties.
    // Composite PK: (video_id, category_id)
    public class VideoCategory
    {
        public Guid VideoId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
