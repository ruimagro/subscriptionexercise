using Microsoft.EntityFrameworkCore;
using Crayon.Application.Common.Interfaces;
using Crayon.Domain.Entities;

namespace Crayon.Repository.Infrastructure;

public class SubscriptionRepository(CrayonDbContext dbContext) : ISubscriptionRepository
{
    public async Task CreateSubscriptionAsync(IEnumerable<Subscription> subscriptions)
    {
        await dbContext.Subscriptions.AddRangeAsync(subscriptions);
    }

    public async Task<int> CancelSubscriptionsAsync(Guid serviceId, int customerId, int quantity)
    {
        var entities = await dbContext.Subscriptions.Where(m => m.CustomerId == customerId && m.ServiceId == serviceId)
            .Take(quantity)
            .ToListAsync();

        if (entities.Count == 0) return 0;

        dbContext.Subscriptions.RemoveRange(entities);

        return entities.Count;
    }

    public async Task<Subscription?> ExtendSubscriptionAsync(int subscriptionId, DateOnly extendToDate)
    {
        var entity = await dbContext.Subscriptions.FirstOrDefaultAsync(m => m.Id == subscriptionId);

        if (entity is not null) entity.ValidUntilDate = extendToDate;

        return entity;
    }

    public async Task<Subscription?> GetSubscriptionAsync(int customerId)
    {
        return await dbContext.Subscriptions.FirstOrDefaultAsync(m => m.CustomerId == customerId);
    }
}

