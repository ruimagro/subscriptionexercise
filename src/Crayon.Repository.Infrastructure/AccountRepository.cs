using Crayon.Application.Common.Interfaces;
using Crayon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crayon.Repository.Infrastructure;

public class AccountRepository(CrayonDbContext dbContext) : IAccountRepository
{
    public async Task<List<Subscription>> GetAccountSubscriptionsAsync(int accountId)
    {
        var result = await dbContext.Subscriptions.Where(m => m.AccountId == accountId)
            .ToListAsync();
        return result;
    }

    public async Task<bool> RemoveSubscriptionFromAccountAsync(int accountId, Guid serviceId)
    {
        var entity = await dbContext.Subscriptions
            .FirstOrDefaultAsync(m => m.AccountId == accountId && m.ServiceId == serviceId);

        if (entity is null) return false;

        entity.AccountId = null;
        //context.Subscriptions.Remove(entity);
        return true;
    }
}