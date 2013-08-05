using PeanutLabs.Configuration;

namespace PeanutLabs.Tests.Fake
{


    public class FabianaConfiguration : IPeanutLabsConfiguration
    {
        public string ApplicationId
        {
            get { return "7457"; }
        }

        public string ApplicationKey
        {
            get { return "fd9e403d27a87892a3b36ecb57b7bce0"; }
        }

        public string BaseUrl
        {
            get { return "http://www.peanutlabs.com/userGreeting.php"; }
        }
    }

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