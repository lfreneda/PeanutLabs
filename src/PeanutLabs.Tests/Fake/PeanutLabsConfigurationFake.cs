using PeanutLabs.Configuration;

namespace PeanutLabs.Tests.Fake
{
    public class PeanutLabsConfigurationFake : IPeanutLabsConfiguration
    {
        public string ApplicationId
        {
            get { return "1111"; }
        }

        public string ApplicationKey
        {
            get { return "mznxbcnmbasmnbdmnb1nmb23213"; }
        }

        public string BaseUrl
        {
            get { return "http://www.peanutlabs.com/userGreeting.php"; }
        }
    }
}