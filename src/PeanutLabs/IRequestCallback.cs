namespace PeanutLabs
{
    public interface IRequestCallback
    {
        string Cmd { get; }
        string UserId { get; }
        decimal Amt { get; }
        string OfferInvitationId { get; }
        string Status { get; }
        string OidHash { get; }
        int CurrencyAmt { get; }
        string TransactionId { get; }
        string GetCustomParameter(string name);
    }
}