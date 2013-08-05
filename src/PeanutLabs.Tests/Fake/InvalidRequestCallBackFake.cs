namespace PeanutLabs.Tests.Fake
{
    public class FabianaTesteCallback : IRequestCallback
    {
        public string Cmd
        {
            get { throw new System.NotImplementedException(); }
        }

        public string UserId
        {
            get { throw new System.NotImplementedException(); }
        }

        public decimal Amt
        {
            get { throw new System.NotImplementedException(); }
        }

        public string OfferInvitationId
        {
            get { return "1"; }
        }

        public string Status
        {
            get { throw new System.NotImplementedException(); }
        }

        public string OidHash
        {
            get { return "b1388dda5242d10b39d9cff4e4d46f71"; }
        }

        public int CurrencyAmt
        {
            get { throw new System.NotImplementedException(); }
        }

        public string TransactionId
        {
            get { throw new System.NotImplementedException(); }
        }

        public string GetCustomParameter(string name)
        {
            throw new System.NotImplementedException();
        }
    }

    public class InvalidRequestCallBackFake : IRequestCallback
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