using Crayon.Domain.Entities;
using MediatR;

namespace Crayon.Application.Feature.Account.Query.GetAccountSubscriptions;

public class GetAccountSubscriptionsQuery : IRequest<List<Domain.Entities.Subscription>>
{
    public int Id { get; set; }
}