using System.Configuration;

namespace PeanutLabs.Configuration
{
    public class PeanutLabsAppSettings : IPeanutLabsConfiguration
    {
        public string ApplicationId {
            get { return ConfigurationManager.AppSettings["peanutlabs.application.id"]; }
        }

        public string ApplicationKey {
            get { return ConfigurationManager.AppSettings["peanutlabs.application.key"]; }
        }

        public string BaseUrl {
            get { return ConfigurationManager.AppSettings["peanutlabs.base.url"]; }
        }
    }
}