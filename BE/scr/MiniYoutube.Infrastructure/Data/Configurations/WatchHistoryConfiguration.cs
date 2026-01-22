using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniYoutube.Core.Entities;

namespace MiniYoutube.Infrastructure.Data.Configurations
{
    public class WatchHistoryConfiguration : IEntityTypeConfiguration<WatchHistory>
    {
        public void Configure(EntityTypeBuilder<WatchHistory> builder)
        {
            builder.HasKey(wh => wh.Id);

            // Relationship: WatchHistory -> User
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(wh => wh.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship: WatchHistory -> Video
            builder.HasOne<Video>()
                .WithMany()
                .HasForeignKey(wh => wh.VideoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
