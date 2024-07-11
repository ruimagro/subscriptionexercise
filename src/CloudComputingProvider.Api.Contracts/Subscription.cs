namespace CloudComputingProvider.Api.Contracts;

public class Subscription
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    public int Quantity { get; set; }
    public DateOnly ExpiryDate { get; set; }
}

