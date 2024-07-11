using Crayon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crayon.Repository.Infrastructure.EntityConfiguration;

public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasData(new Account
        {
            Id = 1,
            Name = "User A-1",
            CustomerId = 1,
        },
        new Account
        {
            Id = 2,
            Name = "User A-2",
            CustomerId = 1
        },
        new Account
        {
            Id = 3,
            Name = "User B-1",
            CustomerId = 2 
        },
        new Account
        {
            Id = 4,
            Name = "User C-1",
            CustomerId = 3
        });
    }
}