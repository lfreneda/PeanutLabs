using PeanutLabs.Configuration;

namespace PeanutLabs.Tests.Fake
{
    public class PeanutLabsCallbackFake : PeanutLabsCallback
    {
        public PeanutLabsCallbackFake(IPeanutLabsConfiguration configuration)
            : base(configuration)
        {
        }

        public int WriteInvalidOutputToResponseStreamCalls { get; set; }
        protected override void WriteInvalidOutputToResponseStream()
        {
            WriteInvalidOutputToResponseStreamCalls++;
        }

        public int WriteValidOutputToResponseStreamCalls { get; set; }
        protected override void WriteValidOutputToResponseStream()
        {
            WriteValidOutputToResponseStreamCalls++;
        }

        public int ProcessCreditCalls { get; set; }
        public bool ProcessCreditResult { get; set; }
        protected override bool ProcessCredit(IRequestCallback requestCallback)
        {
            ProcessCreditCalls++;
            return ProcessCreditResult;
        }

        public int ProcessChargeBackCalls { get; set; }
        public bool ProcessChargeBackResult { get; set; }
        protected override bool ProcessChargeBack(IRequestCallback requestCallback)
        {
            ProcessChargeBackCalls++;
            return ProcessChargeBackResult;
        }

        public int ProcessInvalidRequestCalls { get; set; }
        protected override void ProcessInvalidRequest(IRequestCallback requestCallback)
        {
            ProcessInvalidRequestCalls++;
        }
    }
}