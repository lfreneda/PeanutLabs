using PeanutLabs.Configuration;

namespace PeanutLabs.Tests.Fake
{
    public class PeanutLabsConfigurationWithMissingValuesFake : IPeanutLabsConfiguration
    {
        public string ApplicationId
        {
            get { return ""; }
        }

        public string ApplicationKey
        {
            get { return ""; }
        }

        public string BaseUrl
        {
            get { return ""; }
        }
    }
}