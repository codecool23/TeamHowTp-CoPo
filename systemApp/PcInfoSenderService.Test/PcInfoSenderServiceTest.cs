using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PcInfoSenderService.Test
{
    [TestFixture]
    public class PcInfoSenderServiceTest
    {
        IPcInfoSender sut;

        [OneTimeSetUp]
        public void TestSetup()
        {
            sut = new PcInfoSender();
        }

        [Test]
        public void ShouldGetRuntimeInformation()
        {
            Assert.That(sut.GetRuntimeInformation(), Is.Not.Null);
        }

        [Test]
        public void ShouldGetDeviceInformation()
        {
            Assert.That(sut.GetDeviceInformation(), Is.Not.Null);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            sut = null;
        }
    }
}
