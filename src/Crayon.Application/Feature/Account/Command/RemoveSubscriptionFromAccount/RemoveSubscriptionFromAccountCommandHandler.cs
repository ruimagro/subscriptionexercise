using Crayon.Application.Common.Interfaces;
using Crayon.Application.Feature.Account.Command.CancelAccountSubscription;
using MediatR;

namespace Crayon.Application.Feature.Account.Command.RemoveSubscriptionFromAccount;

public class RemoveSubscriptionFromAccountCommandHandler(IAccountRepository accountRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveSubscriptionFromAccountCommand, bool>
{
    public async Task<bool> Handle(RemoveSubscriptionFromAccountCommand command, CancellationToken cancellationToken)
    {
        var entityFound = await accountRepository.RemoveSubscriptionFromAccountAsync(command.AccountId, command.ServiceId);
        
        if (entityFound) await unitOfWork.CommitChangesAsync();

        return entityFound;
    }
}