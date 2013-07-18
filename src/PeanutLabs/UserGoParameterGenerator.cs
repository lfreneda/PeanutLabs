using System.Configuration;
using Awesomely.Extensions;
using PeanutLabs.Configuration;

namespace PeanutLabs
{
    public class UserGoParameter
    {
        private readonly IPeanutLabsConfiguration _configuration;

        public UserGoParameter(IPeanutLabsConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Generate(int publisherUserId)
        {
            if (string.IsNullOrEmpty(_configuration.ApplicationKey) || string.IsNullOrEmpty(_configuration.ApplicationId))
                throw new ConfigurationErrorsException("ApplicationId Or ApplicationKey must be configured.");

            var data = string.Concat(publisherUserId, _configuration.ApplicationId, _configuration.ApplicationKey);
            var md5 = data.GetMd5Hash();
            return md5.Substring(0, 10);
        }
    }
}