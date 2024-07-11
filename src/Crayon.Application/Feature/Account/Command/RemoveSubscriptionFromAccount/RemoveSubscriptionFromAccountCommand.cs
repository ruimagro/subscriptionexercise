using Crayon.Application.Common.Interfaces;
using MediatR;

namespace Crayon.Application.Feature.Account.Command.CancelAccountSubscription;

public record RemoveSubscriptionFromAccountCommand() 
    : IRequest<bool>
{
    public int AccountId { get; set; }
    public Guid ServiceId { get; set; }
}