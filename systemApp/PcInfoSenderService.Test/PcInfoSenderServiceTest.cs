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
        public void ShouldGetRuntimeInformationUptimeLargerThanZero()
        {
            Assert.That(sut.GetRuntimeInformation().ComputerUpTime.Length, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldGetDeviceInformationHasCDrive()
        {
            List<string> diskNames = new List<string>();
            foreach ( PcInfoModels.DiskSpace disk in sut.GetDeviceInformation() )
            { diskNames.Add(disk.Name); }; 
            Assert.That(diskNames, Has.Member("C:\\"));
        }

        [Test]
        public void ShouldGetAllServices()
        {
            Assert.That(sut.GetAllServices(), Is.Not.Null);
        }

        [Test]
        public void ShouldGetAllProcess()
        {
            Assert.That(sut.GetAllProcess(), Is.Not.Null);
        }

        [Test]
        public void ShouldGetAllProcessHasProcess()
        {
            List<string> procNames = new List<string>();
            foreach (PcInfoModels.Process proc in sut.GetAllProcess())
            { procNames.Add(proc.ProcessName); };
            Assert.That(procNames, Has.Member("winlogon"));
        }

        [Test]
        public void ShouldKillProcess()
        {
            System.Diagnostics.Process cmd  = System.Diagnostics.Process.Start("cmd.exe");
            sut.KillProcess(cmd.Id);
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("cmd.exe");
            Assert.True(proc.Length == 0);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            sut = null;
        }
    }
}
