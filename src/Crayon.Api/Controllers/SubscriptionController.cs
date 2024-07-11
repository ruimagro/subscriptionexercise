using Microsoft.AspNetCore.Mvc;
using CloudComputingProvider.Api.Contracts;
using Crayon.Api.Contracts.Subscription;
using Crayon.Application.Feature.Subscription.Command.CancelSubscriptions;
using Crayon.Application.Feature.Subscription.Command.CreateSubscription;
using Crayon.Application.Feature.Subscription.Command.ExtendSubscription;
using Crayon.Application.Service.Query.GetSubscription;
using MediatR;

namespace Crayon.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionController(IHttpClientFactory httpClientFactory,
    IMediator mediator)
    : ControllerBase
{
    [HttpGet("Services")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        // TODO: move http requests to Application layer
        using var client = httpClientFactory.CreateClient();
        CCPGetAllServicesResponse? services = null;
        // TODO: IOptions
        var response = await client.GetAsync("http://localhost:5028/services");
        
        if (!response.IsSuccessStatusCode) return BadRequest();
        
        services = await response.Content.ReadFromJsonAsync<CCPGetAllServicesResponse>();
        return Ok(services);
    }

    [HttpPost("buy")]
    public async Task<IActionResult> BuySubscription(BuySubscriptionRequest request)
    {
        // place order with CCP
        using var client = httpClientFactory.CreateClient();

        var ccpRequest = new CCPPlaceOrderRequest
        {
            ServiceId = request.ServiceId,
            CustomerId = request.CustomerId,
            Quantity = request.Quantity
        };
        
        // TODO: IOptions for host
        var ccpResponse = await client.PostAsJsonAsync("http://localhost:5028/services/placeorder", ccpRequest);
        if (!ccpResponse.IsSuccessStatusCode) return BadRequest();

        var validUntilDate = DateOnly.FromDateTime(DateTime.UtcNow).AddYears(1);
        
        var command = new BuySubscriptionCommand
        {
            ServiceId = request.ServiceId,
            CustomerId = request.CustomerId,
            Quantity = request.Quantity,
            ValidUntilDate = validUntilDate 
        };
        
        var response = await mediator.Send(command);

        return Ok(response);
    }

    [HttpPost("{subscriptionId:int}")]
    public async Task<IActionResult> GetSubscription(int subscriptionId)
    {
        var query = new GetSubscriptionQuery
        {
            Id = subscriptionId
        };
        var subscription = await mediator.Send(query);

        return subscription is null
            ? NotFound()
            : Ok(subscription);
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelSubscription(CancelSubscriptionsRequest request)
    {
        var command = new CancelSubscriptionsCommand
        {
            ServiceId = request.ServiceId,
            CustomerId = request.CustomerId
        };

        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("extend")]
    public async Task<IActionResult> ExtendSubscription(ExtendSubscriptionRequest request)
    {
        var command = new ExtendSubscriptionCommand
        {
            Id = request.SubscriptionId,
            ExtendToDate = request.ExtendToDate
        };

        var subscription = await mediator.Send(command);
        
        return Ok(subscription);
    }
}