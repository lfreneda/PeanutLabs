namespace PeanutLabs.Tests.Fake
{
    public class ValidRequestCallbackFake : IRequestCallback
    {
        public string Cmd
        { get; set; }

        public string UserId
        { get; set; }

        public decimal Amt
        { get; set; }

        public string OfferInvitationId
        {
            get { return "112"; }
        }

        public string Status
        { get; set; }

        public string OidHash
        {
            get { return "eab35e200fbf2b47b08b3df8aadb87cd"; }
        }

        public int CurrencyAmt
        { get; set; }

        public string TransactionId
        { get; set; }

        public string GetCustomParameter(string name)
        {
            return "";
        }
    }
}