namespace Crayon.Domain.Entities;

public record Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
