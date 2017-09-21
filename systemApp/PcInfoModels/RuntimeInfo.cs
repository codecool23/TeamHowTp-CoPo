using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.Serialization;
using PcInfoModelsFormatter;

namespace PcInfoModels
{
    [DataContract]
    public class RuntimeInfo
    {
        [DataMember]
        public string ComputerUpTime { get; set; }
        [DataMember]
        public string ComputerName { get; set; }
        [DataMember]
        public string OSInfo { get; set; }
        [DataMember]
        public string TotalMemorySize { get; set; }
        [DataMember]
        public DateTime InstallDate { get; set; }
        [DataMember]
        public int ProcessorCount { get; set; }
        [DataMember]
        public string InputLocale { get; set; }
        [DataMember]
        public string SystemLocale { get; set; }

        public RuntimeInfo()
        {
            ComputerUpTime = DateFormatter.ToReadableString(GetComputerUpTime());
            ComputerName = Environment.MachineName;
            OSInfo = Environment.OSVersion.VersionString;
            TotalMemorySize = ByteFormatter.Format(GetTotalMemorySize());
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
