using Crayon.Application.Common.Interfaces;
using Crayon.Domain.Entities;
using MediatR;

namespace Crayon.Application.Service.Query.GetSubscription;

public class GetSubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository)
    : IRequestHandler<GetSubscriptionQuery, Subscription?>
{
    public Task<Subscription?> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
    {
        var subscription = subscriptionRepository.GetSubscriptionAsync(request.Id);

        return subscription;
    }
}
