using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcInfoModels
{
    public class DiskSpace
    {
        public static List<DiskSpace> AllDisk = new List<DiskSpace>();

        public string Name { get; set; }
        public long TotalFreeSpace { get; set; }
        public long TotalReservedSpace { get; set; }
        public long TotalSpace { get; set; }

        private DiskSpace(string name, long freeSpace, long reservedSpace, long totalSpace)
        {
            Name = name;
            TotalFreeSpace = freeSpace;
            TotalReservedSpace = reservedSpace;
            TotalSpace = totalSpace;
        }

        public static void CountSpaces()
        {
            AllDisk.Clear();
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (d.IsReady)
                {
                    AllDisk.Add(new DiskSpace(d.Name, d.TotalFreeSpace, (d.TotalSize - d.TotalFreeSpace), d.TotalSize));
                }
            }
        }
    }
}
