using Crayon.Application.Common.Interfaces;
using MediatR;

namespace Crayon.Application.Feature.Subscription.Command.CreateSubscription;

public class BuySubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<BuySubscriptionCommand, int>
{
    public async Task<int> Handle(BuySubscriptionCommand command, CancellationToken cancellationToken)
    {
        // TODO: Handle quantity insert
        // TODO: sort out service id should be guid from CCP
        // create 1 subscription times quantity
        var subscriptions = Enumerable.Range(0, command.Quantity)
            .Select(x => new Domain.Entities.Subscription
            {
                ServiceId = command.ServiceId,
                CustomerId = command.CustomerId
            });
        
        // Add it to the db
        await subscriptionRepository.CreateSubscriptionAsync(subscriptions);
        await unitOfWork.CommitChangesAsync();

        return 1;
    }
}
