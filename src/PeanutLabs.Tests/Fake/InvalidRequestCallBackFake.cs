namespace PeanutLabs.Tests.Fake
{
    public class InvalidRequestCallBackFake : IRequestCallback
    {
        public string Cmd
        { get; set; }

        public string UserId
        { get; set; }

        public int Amt
        { get; set; }

        public int OfferInvitationId
        {
            get { return 112; }
        }

        public string Status { get; set; }

        public string OidHash
        {
            get { return "czxbnmnBAghdeygquywgeqwxx"; }
        }

        public int CurrencyAmt { get; set; }

        public string TransactionId { get; set; }

        public string GetCustomParameter(string name)
        {
            return "";
        }
    }
}