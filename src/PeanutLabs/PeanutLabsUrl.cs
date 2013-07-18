using System.Configuration;
using Awesomely.Extensions;
using PeanutLabs.Configuration;
using PeanutLabs.Lib;

namespace PeanutLabs
{
    public class PeanutLabsUrl
    {
        private readonly IPeanutLabsConfiguration _configuration;
        private readonly UserIdParameter _userIdParameter;

        public PeanutLabsUrl(IPeanutLabsConfiguration configuration)
        {
            _configuration = configuration;
            _userIdParameter = new UserIdParameter(_configuration);
        }

        public string IframeUrl(int publisherUserId, OptionalParameters optionalParameters = null, object customParameters = null)
        {
            var iframeUrl = GetIframeBaseUrl();
            iframeUrl += "userId={0}".FormatWith(_userIdParameter.Generate(publisherUserId));
            iframeUrl += HandleOptionalParameters(optionalParameters);
            iframeUrl += HandleCustomParameters(customParameters);

            return iframeUrl;
        }

        private string HandleCustomParameters(object customParameters)
        {
            if (customParameters == null) return string.Empty;
            var parametersCollection = customParameters.ToNameValueCollection();
            return string.Concat("&", new CustomParametersBuilder().Transform(parametersCollection));
        }

        private string GetIframeBaseUrl()
        {
            var iframeUrl = _configuration.BaseUrl;
            if (string.IsNullOrEmpty(iframeUrl)) throw new ConfigurationErrorsException("PeanutLabs BaseUrl must be configured.");
            if (!iframeUrl.EndsWith("?")) iframeUrl += "?";
            return iframeUrl;
        }

        private string HandleOptionalParameters(OptionalParameters optionalParameters)
        {
            if (optionalParameters == null) return string.Empty;

            var parameters = "&";
            if (optionalParameters.BirthDate.HasValue)
            {
                parameters += string.Concat("dob=", optionalParameters.BirthDate.Value.ToString("MM-dd-yyyy"), "&");
            }

            if (optionalParameters.Gender != Gender.Unset)
            {
                parameters += string.Concat("sex=", (int)optionalParameters.Gender, "&");
            }

            return parameters.Remove(parameters.Length - 1, 1);
        }
    }
}