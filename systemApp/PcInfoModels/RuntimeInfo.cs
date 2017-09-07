using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PcInfoModels
{
    public class RuntimeInfo
    {
        public TimeSpan ComputerUpTime { get; set; }
        public string ComputerName { get; set; }
        public string OSInfo { get; set; }
        public long TotalMemorySize { get; set; }
        public DateTime InstallDate { get; set; }
        public int ProcessorCount { get; set; }
        public string InputLocale { get; set; }
        public string SystemLocale { get; set; }

        public RuntimeInfo()
        {
            ComputerUpTime = GetComputerUpTime();
            ComputerName = Environment.MachineName;
            OSInfo = Environment.OSVersion.VersionString;
            TotalMemorySize = GetTotalMemorySize();
            InstallDate = GetWindowsInstallationDateTime();
            ProcessorCount = Environment.ProcessorCount;
            InputLocale = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName;
            SystemLocale = GetSysLocale();
        }

        private string GetSysLocale()
        {
            Thread.CurrentThread.CurrentCulture.ClearCachedData();
            return Thread.CurrentThread.CurrentUICulture.Name;
        }

        private long GetTotalMemorySize()
        {
            long size = 0;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.Fixed && d.IsReady)
                size += d.TotalSize;
            }
            return size;
        }

        private TimeSpan GetComputerUpTime()
        {
            int result = Environment.TickCount & Int32.MaxValue;
            return TimeSpan.FromMilliseconds(result);
        }

        private DateTime GetWindowsInstallationDateTime()
        {
            DateTime installDate = new DateTime();
            var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);
            if (key != null)
            {
                DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0);
                object objValue = key.GetValue("InstallDate");
                string stringValue = objValue.ToString();
                Int64 regVal = Convert.ToInt64(stringValue);

                installDate = startDate.AddSeconds(regVal);
            }
            return installDate;
        }
    }
}
