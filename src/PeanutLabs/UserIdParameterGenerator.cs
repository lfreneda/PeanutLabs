using PeanutLabs.Configuration;

namespace PeanutLabs
{
    public class UserIdParameter
    {
        private readonly IPeanutLabsConfiguration _configuration;
        private readonly UserGoParameter _userGoParameter;

        public UserIdParameter(IPeanutLabsConfiguration configuration)
        {
            _configuration = configuration;
            _userGoParameter = new UserGoParameter(_configuration);
        }

        public string Generate(int publisherUserId)
        {
            var userGo = _userGoParameter.Generate(publisherUserId);
            var userId = string.Concat(publisherUserId, "-", _configuration.ApplicationId, "-", userGo);
            return userId;
        }
    }
}
