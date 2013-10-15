using FluentAssertions;
using NUnit.Framework;
using PeanutLabs.Tests.Fake;

namespace PeanutLabs.Tests
{
    [TestFixture]
    public class PeanutLabsCallbackTests
    {
        [Test]
        public void ValidateRequest_WhenReceivedHashIsNotValid_ShouldReturnFalse()
        {
            var peanutLabsCallback = new PeanutLabsCallbackFake(new PeanutLabsConfigurationFake());
            var result = peanutLabsCallback.ValidateRequest(new InvalidRequestCallBackFake());
            result.Should().Be(false);
        }

        [Test]
        public void ValidateRequest_WhenRecevingAValidRequest_ShouldReturnTrue()
        {
            var peanutLabsCallback = new PeanutLabsCallbackFake(new PeanutLabsConfigurationFake());
            var result = peanutLabsCallback.ValidateRequest(new ValidRequestCallbackFake());
            result.Should().Be(true);
        }

        [Test]
        public void Process_WhenRequestCallbackIsInvalid_ShouldCallProcessInvalidRequestOnce()
        {
            var peanutLabsCallback = new PeanutLabsCallbackFake(new PeanutLabsConfigurationFake());
            peanutLabsCallback.Process(new InvalidRequestCallBackFake());
            peanutLabsCallback.ProcessInvalidRequestCalls.Should().Be(1);
        }

        [Test]
        public void Process_WhenRequestCallbackIsInvalid_ShouldCallWriteInvalidOutputToResponseStreamOnce()
        {
            var peanutLabsCallback = new PeanutLabsCallbackFake(new PeanutLabsConfigurationFake());
            peanutLabsCallback.Process(new InvalidRequestCallBackFake());
            peanutLabsCallback.WriteValidOutputToResponseStreamCalls.Should().Be(0);
            peanutLabsCallback.WriteInvalidOutputToResponseStreamCalls.Should().Be(1);
        }

        [Test]
        public void Process_WhenRequestCallbackIsValidAndProcessCreditHasFailed_ShouldCallWriteInvalidOutputToResponseStreamOnce()
        {
            var peanutLabsCallback = new PeanutLabsCallbackFake(new PeanutLabsConfigurationFake())
            {
                ProcessCreditResult = false
            };

            peanutLabsCallback.Process(new ValidRequestCallbackFake());
            peanutLabsCallback.ProcessCreditCalls.Should().Be(1);
            peanutLabsCallback.ProcessChargeBackCalls.Should().Be(0);
            peanutLabsCallback.WriteValidOutputToResponseStreamCalls.Should().Be(0);
            peanutLabsCallback.WriteInvalidOutputToResponseStreamCalls.Should().Be(1);
        }

        [Test]
        public void Process_WhenRequestCallbackIsValidAndProcessCreditWasSuccessfully_ShouldCallWriteValidOutputToResponseStreamOnce()
        {
            var peanutLabsCallback = new PeanutLabsCallbackFake(new PeanutLabsConfigurationFake())
            {
                ProcessCreditResult = true
            };

            peanutLabsCallback.Process(new ValidRequestCallbackFake());
            peanutLabsCallback.ProcessCreditCalls.Should().Be(1);
            peanutLabsCallback.ProcessChargeBackCalls.Should().Be(0);
            peanutLabsCallback.WriteValidOutputToResponseStreamCalls.Should().Be(1);
            peanutLabsCallback.WriteInvalidOutputToResponseStreamCalls.Should().Be(0);
        }

        [Test]
        public void Process_WhenRequestCallbackIsValidAndChargeBackWasSuccessfully_ShouldCallWriteValidOutputToResponseStreamOnce()
        {
            var peanutLabsCallback = new PeanutLabsCallbackFake(new PeanutLabsConfigurationFake())
            {
                ProcessChargeBackResult = true
            };

            peanutLabsCallback.Process(new ValidRequestCallbackFake { Amt = -1 }); //Chargeback
            peanutLabsCallback.WriteValidOutputToResponseStreamCalls.Should().Be(1);
            peanutLabsCallback.WriteInvalidOutputToResponseStreamCalls.Should().Be(0);
            peanutLabsCallback.ProcessCreditCalls.Should().Be(0);
            peanutLabsCallback.ProcessChargeBackCalls.Should().Be(1);
        }

        [Test]
        public void Process_WhenRequestCallbackIsValidAndChargeBackHasFailed_ShouldCallWriteValidOutputToResponseStreamOnce()
        {
            var peanutLabsCallback = new PeanutLabsCallbackFake(new PeanutLabsConfigurationFake())
            {
                ProcessChargeBackResult = false
            };

            peanutLabsCallback.Process(new ValidRequestCallbackFake { Amt = -1 }); //Chargeback
            peanutLabsCallback.WriteValidOutputToResponseStreamCalls.Should().Be(0);
            peanutLabsCallback.WriteInvalidOutputToResponseStreamCalls.Should().Be(1);
            peanutLabsCallback.ProcessCreditCalls.Should().Be(0);
            peanutLabsCallback.ProcessChargeBackCalls.Should().Be(1);
        }
    }
}
