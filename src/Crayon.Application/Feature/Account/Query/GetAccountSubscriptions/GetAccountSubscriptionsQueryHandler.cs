using Crayon.Application.Common.Interfaces;
using Crayon.Domain.Entities;
using MediatR;

namespace Crayon.Application.Feature.Account.Query.GetAccountSubscriptions;

public class GetAccountSubscriptionsQueryHandler(IAccountRepository accountRepository)
    : IRequestHandler<GetAccountSubscriptionsQuery, List<Domain.Entities.Subscription>>
{
    public async Task<List<Domain.Entities.Subscription>> Handle(GetAccountSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var result = await accountRepository.GetAccountSubscriptionsAsync(request.Id);
        return result;
    }
}