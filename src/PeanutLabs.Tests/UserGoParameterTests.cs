using System.Configuration;
using FluentAssertions;
using NUnit.Framework;
using PeanutLabs.Tests.Fake;

namespace PeanutLabs.Tests
{
    [TestFixture]
    public class UserGoParameterTests
    {
        [Test]
        public void Generate_ShouldBeTheFirst10LettersOfAMd5HashOfPublisherUserIdInApplicationWithApplicationIdWithApplicationKey()
        {
            var userId = new UserGoParameter(new PeanutLabsConfigurationFake());
            userId.Generate(1508).Should().Be("4191f7fb63");
        }

        [Test]
        public void Generate_WhenApplicationIdOrApplicationKeyIsNotConfigured_ShouldThrowsException()
        {
            var userId = new UserGoParameter(new PeanutLabsConfigurationWithMissingValuesFake());
            Assert.That(() => userId.Generate(1508),
                          Throws
                          .Exception
                          .InstanceOf<ConfigurationErrorsException>()
                          .With.Message.EqualTo("ApplicationId Or ApplicationKey must be configured."));
        }
    }
}
