namespace CloudComputingProvider.Api.Contracts;

public class CCPPlaceOrderRequest
{
    public int CustomerId { get; set; }
    public Guid ServiceId { get; set; }
    public int Quantity { get; set; }
}
