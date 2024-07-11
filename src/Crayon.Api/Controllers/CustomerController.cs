using Crayon.Application.Feature.Customer.Query.GetCustomerAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crayon.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(IMediator mediator) : ControllerBase
{
    [HttpGet("{customerId:int}")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int customerId)
    {
        var command = new GetCustomerAccountsQuery
        {
            Id = customerId
        };
        var result = await mediator.Send(command);
        
        return Ok(result);
    }
}