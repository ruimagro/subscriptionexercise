namespace Crayon.Domain.Entities;

public record Account
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CustomerId { get; set; }
}