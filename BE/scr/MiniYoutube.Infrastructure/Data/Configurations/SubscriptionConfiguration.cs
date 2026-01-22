using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniYoutube.Core.Entities;

namespace MiniYoutube.Infrastructure.Data.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);

            // Relationship: Subscription -> Subscriber (User)
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.SubscriberId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship: Subscription -> Channel (User)
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.ChannelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique Constraint: User subscribes to channel once
            builder.HasIndex(s => new { s.SubscriberId, s.ChannelId }).IsUnique();
        }
    }
}
