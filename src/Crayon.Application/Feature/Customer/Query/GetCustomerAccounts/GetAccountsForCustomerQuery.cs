using MediatR;

namespace Crayon.Application.Feature.Customer.Query.GetCustomerAccounts;

public class GetCustomerAccountsQuery : IRequest<List<Domain.Entities.Account>>
{
    public int Id;
}