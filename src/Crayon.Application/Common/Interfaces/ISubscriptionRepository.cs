using Crayon.Domain.Entities;

namespace Crayon.Application.Common.Interfaces;

public interface ISubscriptionRepository
{
    Task<Subscription?> GetSubscriptionAsync(int id);
    Task CreateSubscriptionAsync(IEnumerable<Subscription> subscriptions);
    Task<int> CancelSubscriptionsAsync(Guid serviceId, int customerId, int quantity);
    Task<Subscription?> ExtendSubscriptionAsync(int subscriptionId, DateOnly extendToDate);
}