using FluentAssertions;
using NUnit.Framework;
using PeanutLabs.Tests.Fake;

namespace PeanutLabs.Tests
{
    [TestFixture]
    public class UserIdParameterTests
    {
        [Test]
        public void Generate_ShouldBePublisherUserIdWithApplicationIdWithUserGo()
        {
            var userIdGenerator = new UserIdParameter(new PeanutLabsConfigurationFake());
            var userIdParameter = userIdGenerator.Generate(publisherUserId: 1508);
            userIdParameter.Should().Be("1508-1111-4191f7fb63");
        }
    }
}