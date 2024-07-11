namespace Crayon.Api.Contracts.Account;

public class RemoveSubscriptionFromAccountRequest
{
    public int AccountId { get; set; }
    public Guid ServiceId { get; set; }
}