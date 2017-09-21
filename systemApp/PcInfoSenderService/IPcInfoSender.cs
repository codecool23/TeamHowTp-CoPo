using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PcInfoModels;
using System.ServiceProcess;
using System.Diagnostics;

namespace PcInfoSenderService
{
    [ServiceContract]
    public interface IPcInfoSender
    {
        [OperationContract]
        RuntimeInfo GetRuntimeInformation();

        [OperationContract]
        List<DiskSpace> GetDeviceInformation();

        [OperationContract]
        List<Service> GetAllServices();

        [OperationContract]
        List<PcInfoModels.Process> GetAllProcess();

        [OperationContract]
        void KillProcess(int pid);
    }
}
