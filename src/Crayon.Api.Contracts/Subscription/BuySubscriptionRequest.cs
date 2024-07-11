namespace Crayon.Api.Contracts.Subscription;

public class BuySubscriptionRequest
{
    public Guid ServiceId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }

}
