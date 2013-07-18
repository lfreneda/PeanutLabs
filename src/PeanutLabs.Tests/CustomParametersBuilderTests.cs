using System.Collections.Specialized;
using FluentAssertions;
using NUnit.Framework;
using PeanutLabs.Lib;

namespace PeanutLabs.Tests
{
    [TestFixture]
    public class CustomParametersBuilderTests
    {

        //## Custom URL Parameters
        //You can add your own custom parameters to the IFRAME SRC. Define your parameter
        //name in 'var_key_X' and parameter value in 'var_val_X' (where X can be 1, 2,3). You
        //may chain 3 custom parameters.

        //## Example Custom Parameters:
        //...&var_key_1=abc&var_val_1=xyz&...
        //Would give you the following in the post back:
        //..&abc=xyz&..

        //## Multiple Custom Parameters:
        //...&var_key_1=firstName&var_val_1=bob&var_key_2=lastName&var_val_2=smith…
        //Would give you the following in the post back:
        //&firstname=bob&lastname=smith

        [Test]
        public void Transform_GivenAKeyAndValue_ShouldReturnQueryStringParameter()
        {
            var customParametersBuilder = new CustomParametersBuilder();
            var customParametersUrl = customParametersBuilder.Transform("abc", "xyz");
            customParametersUrl.Should().Be("var_key_1=abc&var_val_1=xyz");
        }

        [Test]
        public void Transform_GivenMultitplesKeysAndValues_ShouldReturnQueryStringParameter()
        {
            var customParametersBuilder = new CustomParametersBuilder();
            var customParametersUrl = customParametersBuilder.Transform(new NameValueCollection { { "firstName", "bob" }, { "lastName", "smith" } });
            customParametersUrl.Should().Be("var_key_1=firstName&var_val_1=bob&var_key_2=lastName&var_val_2=smith");
        }
    }
}