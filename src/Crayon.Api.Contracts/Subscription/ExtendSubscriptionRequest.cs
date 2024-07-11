namespace Crayon.Api.Contracts.Subscription;

public record ExtendSubscriptionRequest
{
    public int SubscriptionId { get; init; }
    public DateOnly ExtendToDate { get; init; }
}