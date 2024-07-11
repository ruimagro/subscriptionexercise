using Crayon.Application.Common.Interfaces;
using Crayon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crayon.Repository.Infrastructure;

public class CustomerRepository(CrayonDbContext dbContext) : ICustomerRepository
{
    public async Task<List<Account>> GetCustomerAccountsAsync(int customerId)
    {
        var result = await dbContext.Accounts.Where(m => m.CustomerId == customerId).ToListAsync();
        return result;
    }
}