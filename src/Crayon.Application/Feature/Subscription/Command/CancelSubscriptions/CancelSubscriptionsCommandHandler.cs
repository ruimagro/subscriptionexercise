using Crayon.Application.Common.Interfaces;
using MediatR;

namespace Crayon.Application.Feature.Subscription.Command.CancelSubscriptions;

public class CancelSubscriptionsCommandHandler(ISubscriptionRepository subscriptionRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CancelSubscriptionsCommand, int>
{
    public async Task<int> Handle(CancelSubscriptionsCommand request, CancellationToken cancellationToken)
    {
        var recordsDeleted = await subscriptionRepository.CancelSubscriptionsAsync(request.ServiceId, request.CustomerId, request.Quantity);
        if (recordsDeleted > 0) await unitOfWork.CommitChangesAsync();
        
        return recordsDeleted;
    }
}
