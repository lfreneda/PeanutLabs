using PeanutLabs.Configuration;

namespace PeanutLabs.Web.Webforms
{
    public class PeanutLabsCallbackSample : PeanutLabsCallback
    {
        public PeanutLabsCallbackSample(IPeanutLabsConfiguration configuration)
            : base(configuration)
        {
        }

        protected override bool ProcessCredit(IRequestCallback requestCallback)
        {
            //implement credit logic here.
            return true;
        }

        protected override bool ProcessChargeBack(IRequestCallback requestCallback)
        {
            //implement chargeback logic here.
            return true;
        }

        protected override void ProcessInvalidRequest(IRequestCallback requestCallback)
        {
            //implement invalid request logic here 
        }
    }
}