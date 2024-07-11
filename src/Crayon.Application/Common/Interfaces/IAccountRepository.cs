using Crayon.Domain.Entities;

namespace Crayon.Application.Common.Interfaces;

public interface IAccountRepository
{
    Task<List<Subscription>> GetAccountSubscriptionsAsync(int accountId);

    Task<bool> RemoveSubscriptionFromAccountAsync(int accountId, Guid serviceId);
}
