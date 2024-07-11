using Crayon.Application.Common.Interfaces;
using MediatR;

namespace Crayon.Application.Feature.Subscription.Command.ExtendSubscription;

public class ExtendSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ExtendSubscriptionCommand, Domain.Entities.Subscription?>
{
    public async Task<Domain.Entities.Subscription?> Handle(ExtendSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionRepository.ExtendSubscriptionAsync(request.Id, request.ExtendToDate);

        if (subscription is not null) await unitOfWork.CommitChangesAsync();
        
        return subscription;
    }
}