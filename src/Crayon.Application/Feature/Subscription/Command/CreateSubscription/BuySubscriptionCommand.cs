using MediatR;

namespace Crayon.Application.Feature.Subscription.Command.CreateSubscription;

public record BuySubscriptionCommand : IRequest<int>
{
    public Guid ServiceId { get; init; }
    public int CustomerId { get; init; }
    public int Quantity { get; init; }
    public DateOnly ValidUntilDate { get; init; }
}