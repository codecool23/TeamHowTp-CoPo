using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PcInfoModels;
using System.ServiceProcess;

namespace PcInfoSenderService
{
    [ServiceContract]
    public interface IPcInfoSender
    {
        [OperationContract]
        RuntimeInfo GetRuntimeInformation();

        [OperationContract]
        List<DiskSpace> GetDeviceInformation(string stringIn);

        [OperationContract]
        ServiceController[] GetAllServices();
    }
}
