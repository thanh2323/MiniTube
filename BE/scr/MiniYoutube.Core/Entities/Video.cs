using System;
using MiniYoutube.Core.Enums;

namespace MiniYoutube.Core.Entities
{
    public class Video : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public int DurationSeconds { get; set; }
        public VideoVisibility Visibility { get; set; } = VideoVisibility.Public; // PUBLIC | PRIVATE | UNLISTED
        public VideoStatus Status { get; set; } = VideoStatus.Processing; // PROCESSING | READY | BLOCKED
        public long ViewCount { get; set; }
        public long LikeCount { get; set; }
    }
}
