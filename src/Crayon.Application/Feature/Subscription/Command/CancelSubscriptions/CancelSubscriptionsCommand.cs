using MediatR;

namespace Crayon.Application.Feature.Subscription.Command.CancelSubscriptions;

public record CancelSubscriptionsCommand : IRequest<int>
{
    public Guid ServiceId { get; init; }
    public int CustomerId { get; init; }
    public int Quantity { get; init; }
    
}