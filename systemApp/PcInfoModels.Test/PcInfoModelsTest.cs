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
        public void ShouldDiskSpaceCountSpaces()
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

        [OneTimeTearDown]
        public void TestTearDown()
        {
            runTimeInfo = null;
        }
    }
}
