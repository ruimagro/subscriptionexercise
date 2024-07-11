using Crayon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crayon.Repository.Infrastructure.EntityConfiguration;

public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasData(new Subscription
            { 
                Id = 1,
                CustomerId = 1,
                ServiceId = new Guid("6cb82bcb-0f88-4708-bf3b-b926aa4d7027"),
                AccountId = 1,
                ValidUntilDate = DateOnly.FromDateTime(DateTime.UtcNow).AddYears(1)
            },
            new Subscription
            {
                Id = 2,
                CustomerId = 3,
                ServiceId = new Guid("6cb82bcb-0f88-4708-bf3b-b926aa4d7027"),
                AccountId = null,  // unassigned subscription
                ValidUntilDate = DateOnly.FromDateTime(DateTime.UtcNow).AddYears(1)
            });
    }
}