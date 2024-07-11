using Crayon.Domain.Entities;

namespace Crayon.Application.Common.Interfaces;

public interface ICustomerRepository
{
    Task<List<Account>> GetCustomerAccountsAsync(int customerId);
}