using System.Reflection;
using Crayon.Application.Common.Interfaces;
using Crayon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crayon.Repository.Infrastructure;

public class CrayonDbContext(DbContextOptions<CrayonDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        base.OnModelCreating(modelBuilder);
    }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}
