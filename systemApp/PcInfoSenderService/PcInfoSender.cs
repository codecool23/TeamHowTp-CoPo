using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PcInfoModels;
using System.ServiceProcess;
using System.Diagnostics;

namespace PcInfoSenderService
{
    public class PcInfoSender : IPcInfoSender
    {
        public RuntimeInfo GetRuntimeInformation()
        {
            return new RuntimeInfo();
        }

        public List<DiskSpace> GetDeviceInformation()
        {
            DiskSpace.CountSpaces();
            return DiskSpace.AllDisk;
        }

        public List<Service> GetAllServices()
        {
            List<Service> result = new List<Service>();
            foreach (ServiceController service in ServiceController.GetServices())
            {
                if (service.Status == ServiceControllerStatus.Running)
                {
                    result.Add(new Service(service.ServiceName));
                }
            }
            return result;
        }

        public List<PcInfoModels.Process> GetAllProcess()
        {
            List<PcInfoModels.Process> result = new List<PcInfoModels.Process>();
            foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcesses())
            {
                result.Add(new PcInfoModels.Process(proc.ProcessName, proc.Id));
            }
            return result;
        }
    }
}
