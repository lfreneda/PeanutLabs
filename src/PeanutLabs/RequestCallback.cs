using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace PeanutLabs
{
    public class RequestCallback : IRequestCallback
    {
        public RequestCallback()
        {
            if (HttpContext.Current == null) throw new NoNullAllowedException("HttpContext.Current cannot be null.");
            if (HttpContext.Current.Request == null) throw new NoNullAllowedException("HttpContext.Current.Request cannot be null.");

            var httpRequest = HttpContext.Current.Request;
            Cmd = httpRequest["cmd"];
            UserId = httpRequest["userId"];
            Amt = Convert.ToDecimal(httpRequest["amt"]);
            OfferInvitationId = httpRequest["offerInvitationId"];
            Status = httpRequest["status"];
            OidHash = httpRequest["oidHash"];
            CurrencyAmt = Convert.ToInt32(httpRequest["currencyAmt"]);
            TransactionId = httpRequest["transactionId"];
            CustomParameters = new Dictionary<string, string>();
        }

        public RequestCallback(params string[] customParameters)
            : this()
        {
            var httpRequest = HttpContext.Current.Request;

            foreach (var customParameter in customParameters)
            {
                CustomParameters.Add(customParameter, httpRequest[customParameter]);
            }
        }

        public string Cmd { get; protected set; }
        public string UserId { get; protected set; }
        public decimal Amt { get; protected set; }
        public string OfferInvitationId { get; protected set; }
        public string Status { get; protected set; }
        public string OidHash { get; protected set; }
        public int CurrencyAmt { get; protected set; }
        public string TransactionId { get; protected set; }

        public string GetCustomParameter(string name)
        {
            return !CustomParameters.ContainsKey(name) ? null : CustomParameters[name];
        }

        private IDictionary<string, string> CustomParameters { get; set; }
    }
}