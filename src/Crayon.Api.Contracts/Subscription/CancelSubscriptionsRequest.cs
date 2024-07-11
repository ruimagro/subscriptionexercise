namespace Crayon.Api.Contracts.Subscription;

public record CancelSubscriptionsRequest
{
    public Guid ServiceId { get; init; }
    public int CustomerId { get; init; }
}