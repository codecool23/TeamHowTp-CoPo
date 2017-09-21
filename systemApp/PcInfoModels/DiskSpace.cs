using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PcInfoModelsFormatter;

namespace PcInfoModels
{
    [DataContract]
    public class DiskSpace
    {
        [DataMember]
        public static List<DiskSpace> AllDisk = new List<DiskSpace>();
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string TotalFreeSpace { get; set; }
        [DataMember]
        public string TotalReservedSpace { get; set; }
        [DataMember]
        public string TotalSpace { get; set; }

        private DiskSpace(string name, long freeSpace, long reservedSpace, long totalSpace)
        {
            Name = name;
            TotalFreeSpace = ByteFormatter.Format(freeSpace);
            TotalReservedSpace = ByteFormatter.Format(reservedSpace);
            TotalSpace = ByteFormatter.Format(totalSpace);
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
