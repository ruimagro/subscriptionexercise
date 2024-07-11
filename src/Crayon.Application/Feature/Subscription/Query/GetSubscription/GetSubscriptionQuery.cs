using Crayon.Domain.Entities;
using MediatR;

namespace Crayon.Application.Service.Query.GetSubscription;

public record GetSubscriptionQuery : IRequest<Subscription?>
{
    public int Id { get; init; }
}