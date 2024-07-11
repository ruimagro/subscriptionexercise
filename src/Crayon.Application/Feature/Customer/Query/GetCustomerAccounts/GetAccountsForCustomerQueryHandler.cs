using Crayon.Application.Common.Interfaces;
using MediatR;

namespace Crayon.Application.Feature.Customer.Query.GetCustomerAccounts;

public class GetCustomerAccountsQueryHandler(ICustomerRepository customerRepository)
    : IRequestHandler<GetCustomerAccountsQuery, List<Domain.Entities.Account>>
{
    public async Task<List<Domain.Entities.Account>> Handle(GetCustomerAccountsQuery request, CancellationToken cancellationToken)
    {
        var result = await customerRepository.GetCustomerAccountsAsync(request.Id);
        return result;
    }
}