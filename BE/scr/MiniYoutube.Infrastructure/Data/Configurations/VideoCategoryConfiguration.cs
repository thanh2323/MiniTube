using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniYoutube.Core.Entities;

namespace MiniYoutube.Infrastructure.Data.Configurations
{
    public class VideoCategoryConfiguration : IEntityTypeConfiguration<VideoCategory>
    {
        public void Configure(EntityTypeBuilder<VideoCategory> builder)
        {
            // Composite Key
            builder.HasKey(vc => new { vc.VideoId, vc.CategoryId });

            // Relationship: VideoCategory -> Video
            builder.HasOne<Video>()
                .WithMany()
                .HasForeignKey(vc => vc.VideoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship: VideoCategory -> Category
            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(vc => vc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
