using System;
using System.Configuration;
using FluentAssertions;
using NUnit.Framework;
using PeanutLabs.Tests.Fake;

namespace PeanutLabs.Tests
{
    [TestFixture]
    public class PeanutLabsUrlTests
    {
        [Test]
        public void IframeUrl_PeanutLabsBaseUrlShouldBeConfigured()
        {
            var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsConfigurationWithMissingValuesFake());
            Assert.That(()=> peanutLabsUrl.IframeUrl(1508), 
                    Throws
                    .Exception
                    .InstanceOf<ConfigurationErrorsException>()
                    .With
                    .Message
                    .EqualTo("PeanutLabs BaseUrl must be configured."));
        }

        [Test]
        public void IframeUrl_ShouldStartWithPeanutsDefaultUrl()
        {
            const string startWithExpected = "http://www.peanutlabs.com/userGreeting.php?userId=1508-1111-4191f7fb63";
            var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsConfigurationFake());
            var url = peanutLabsUrl.IframeUrl(1508);
            url.Should().StartWith(startWithExpected);
        }

        [Test]
        public void IframeUrl_WhenBirthDateWasProvided_ShouldReturnUrlWithBirthDate()
        {
            const string urlExpected = "http://www.peanutlabs.com/userGreeting.php?userId=1508-1111-4191f7fb63&dob=05-15-1988";
            var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsConfigurationFake());
            var url = peanutLabsUrl.IframeUrl(1508, new OptionalParameters(new DateTime(1988, 05, 15)));
            url.Should().StartWith(urlExpected);
        }

        [Test]
        public void IframeUrl_WhenGenderDateWasProvided_ShouldReturnUrlWithGender()
        {
            const string urlExpected = "http://www.peanutlabs.com/userGreeting.php?userId=1508-1111-4191f7fb63&sex=2";
            var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsConfigurationFake());
            var url = peanutLabsUrl.IframeUrl(1508, new OptionalParameters(Gender.Female));
            url.Should().StartWith(urlExpected);
        }

        [Test]
        public void IframeUrl_WhenOptionalParamatersWereProvided_ShouldReturnCompleteUrl()
        {
            const string urlExpected = "http://www.peanutlabs.com/userGreeting.php?userId=1508-1111-4191f7fb63&dob=05-15-1988&sex=1";
            var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsConfigurationFake());
            var url = peanutLabsUrl.IframeUrl(1508, new OptionalParameters(new DateTime(1988, 05, 15), Gender.Male));
            url.Should().StartWith(urlExpected);
        }

        [Test]
        public void IframeUrl_WhenOptionalParamatersAndCustomParametersWereProvided_ShouldReturnCompleteUrl()
        {
            const string urlExpected = "http://www.peanutlabs.com/userGreeting.php?userId=1508-1111-4191f7fb63&dob=05-15-1988&sex=1&var_key_1=firstName&var_val_1=Luiz&var_key_2=lastName&var_val_2=Freneda&var_key_3=likes&var_val_3=bacon";
            var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsConfigurationFake());
            var url = peanutLabsUrl.IframeUrl(1508, new OptionalParameters(new DateTime(1988, 05, 15), Gender.Male), new {
                                                                                                                            firstName = "Luiz",
                                                                                                                            lastName = "Freneda",
                                                                                                                            likes = "bacon" 
                                                                                                                         });
            url.Should().StartWith(urlExpected);
        }


    }


}