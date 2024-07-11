using MediatR;

namespace Crayon.Application.Feature.Subscription.Command.ExtendSubscription;

public record ExtendSubscriptionCommand : IRequest<Domain.Entities.Subscription?>
{
    public int Id { get; init; }
    public DateOnly ExtendToDate { get; init; }
}