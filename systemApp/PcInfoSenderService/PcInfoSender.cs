using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PcInfoModels;
using System.ServiceProcess;

namespace PcInfoSenderService
{
    public class PcInfoSender : IPcInfoSender
    {
        public RuntimeInfo GetRuntimeInformation()
        {
            return new RuntimeInfo();
        }

        public List<DiskSpace> GetDeviceInformation(string stringIn)
        {
            DiskSpace.CountSpaces();
            return DiskSpace.AllDisk;
        }

        public ServiceController[] GetAllServices()
        {
            return ServiceController.GetServices();
        }
        
    }
}
