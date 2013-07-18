namespace PeanutLabs
{
    public interface IRequestCallback
    {
        string Cmd { get; }
        string UserId { get; }
        int Amt { get; }
        int OfferInvitationId { get; }
        string Status { get; }
        string OidHash { get; }
        int CurrencyAmt { get; }
        string TransactionId { get; }
        string GetCustomParameter(string name);
    }
}