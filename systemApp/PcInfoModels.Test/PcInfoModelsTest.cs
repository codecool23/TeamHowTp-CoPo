using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PcInfoModels;

namespace PcInfoModels.Test
{
    [TestFixture] 
    public class PcInfoModelsTest
    {
        RuntimeInfo runTimeInfo;

        [OneTimeSetUp]
        public void TestSetup()
        {
           runTimeInfo = new RuntimeInfo();
        }

        [Test]
        public void ShouldDiskSpaceCountSpacesNumofDrives()
        {
            DiskSpace.CountSpaces();
            Assert.That(DiskSpace.AllDisk.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void ShouldRuntimeInfoGetWindowsInstallationDateTime()
        {
            DateTime testDate = new DateTime(1984, 1, 1, 0, 0, 0);
            Assert.True(runTimeInfo.InstallDate > testDate );
            
        }

        [Test]
        public void ShouldGetTotalMemorySize()
        {
            Assert.That(runTimeInfo.TotalMemorySize.Length, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldGetSysLocale()
        {
            Assert.That(runTimeInfo.SystemLocale, Is.EqualTo("en-US"));
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            runTimeInfo = null;
        }
    }
}
