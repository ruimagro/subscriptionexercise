using Crayon.Api.Contracts.Account;
using Crayon.Application.Feature.Account.Command.CancelAccountSubscription;
using Crayon.Application.Feature.Account.Query.GetAccountSubscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crayon.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpGet("{accountId:int}/subscriptions")]
    public async Task<IActionResult> GetAccountSubscriptions(int accountId)
    {
        var command = new GetAccountSubscriptionsQuery
        {
            Id = accountId
        };

        var result = await mediator.Send(command);
        
        return Ok(result);
    }
    
    [HttpPut("/subscriptions/remove")]
    public async Task<IActionResult> RemoveSubscriptionFromAccount(RemoveSubscriptionFromAccountRequest request)
    {
        var command = new RemoveSubscriptionFromAccountCommand
        {
            AccountId = request.AccountId,
            ServiceId = request.ServiceId
        };

        var result = await mediator.Send(command);

        return result ? Ok() : BadRequest();
    }
}