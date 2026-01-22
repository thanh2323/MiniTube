using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniYoutube.Core.Entities;

namespace MiniYoutube.Infrastructure.Data.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(v => v.Description)
                .HasMaxLength(5000);

            // Relationship: Video -> User
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
