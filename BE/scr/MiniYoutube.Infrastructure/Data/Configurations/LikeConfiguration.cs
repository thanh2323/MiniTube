using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniYoutube.Core.Entities;

namespace MiniYoutube.Infrastructure.Data.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => l.Id);

            // Relationship: Like -> User
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique Constraint: User can like a target only once
            builder.HasIndex(l => new { l.UserId, l.TargetId, l.TargetType }).IsUnique();
        }
    }
}
