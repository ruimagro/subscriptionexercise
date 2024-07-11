namespace Crayon.Domain.Entities;

public record Subscription
{
    public int Id { get; set; }
    public Guid ServiceId { get; set; }
    public int? CustomerId { get; set; }
    public int? AccountId { get; set; }
    public DateOnly ValidUntilDate { get; set; }
}
