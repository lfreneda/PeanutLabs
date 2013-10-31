using System.Web;
using Awesomely.Extensions;
using PeanutLabs.Configuration;

namespace PeanutLabs
{
    public abstract class PeanutLabsCallback : IPeanutLabsCallback
    {
        private readonly IPeanutLabsConfiguration _configuration;

        protected PeanutLabsCallback(IPeanutLabsConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool ValidateRequest(IRequestCallback requestCallback)
        {
            var offerInvitationId = requestCallback.OfferInvitationId;
            var hash = string.Concat(offerInvitationId, _configuration.ApplicationKey).GetMd5Hash();
            return requestCallback.OidHash == hash;
        }

        protected virtual void WriteValidOutputToResponseStream()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("1");
            HttpContext.Current.Response.End();
        }

        protected virtual void WriteInvalidOutputToResponseStream()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("0");
            HttpContext.Current.Response.End();
        }

        public void Process(IRequestCallback requestCallback)
        {
            if (!ValidateRequest(requestCallback))
            {
                ProcessInvalidRequest(requestCallback);
                WriteInvalidOutputToResponseStream();
                return;
            }

            if (IsComplete(requestCallback))
            {
                ProcessRequest(requestCallback);
            }
        }

        private bool IsComplete(IRequestCallback requestCallback)
        {
            return requestCallback.Status == "C";
        }

        private void ProcessRequest(IRequestCallback requestCallback)
        {
            if (IsChargeBack(requestCallback))
            {
                ChargeBackRequest(requestCallback);
            }
            else
            {
                CreditRequest(requestCallback);
            }
        }

        private void CreditRequest(IRequestCallback requestCallback)
        {
            if (ProcessCredit(requestCallback))
            {
                WriteValidOutputToResponseStream();
            }
            else
            {
                WriteInvalidOutputToResponseStream();
            }
        }

        private void ChargeBackRequest(IRequestCallback requestCallback)
        {
            if (ProcessChargeBack(requestCallback))
            {
                WriteValidOutputToResponseStream();
            }
            else
            {
                WriteInvalidOutputToResponseStream();
            }
        }

        private bool IsChargeBack(IRequestCallback requestCallback)
        {
            return requestCallback.Amt < 0;
        }

        protected abstract bool ProcessCredit(IRequestCallback requestCallback);
        protected abstract bool ProcessChargeBack(IRequestCallback requestCallback);
        protected abstract void ProcessInvalidRequest(IRequestCallback requestCallback);
    }
}