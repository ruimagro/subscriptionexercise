using Crayon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crayon.Repository.Infrastructure.EntityConfiguration;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasData(new Customer
            {
                Id = 1,
                Name = "Business A"
            },
            new Customer
            {
                Id = 2, Name = "Business B",
                
            },
            new Customer
            {
                Id = 3, Name = "Business C",
            });
    }
}