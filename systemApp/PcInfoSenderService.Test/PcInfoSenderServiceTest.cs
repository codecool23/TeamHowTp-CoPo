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

        [Test]
        public void ShouldGetRuntimeInformationHasOneCore()
        {
            Assert.That(sut.GetRuntimeInformation().ProcessorCount, Is.AtLeast(1));
        }

        [Test]
        public void ShouldGetDeviceInformationHasCDrive()
        {
            List<string> disknames = new List<string>();
            foreach ( PcInfoModels.DiskSpace disk in sut.GetDeviceInformation() )
            { disknames.Add(disk.Name); }; 
            Assert.That(disknames, Has.Member("C:\\"));
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            sut = null;
        }
    }
}
