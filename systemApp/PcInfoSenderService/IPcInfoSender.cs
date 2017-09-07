using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PcInfoModels;

namespace PcInfoSenderService
{
    [ServiceContract]
    public interface IPcInfoSender
    {
        [OperationContract]
        RuntimeInfo GetRuntimeInformation();

        [OperationContract]
        string GetDeviceInformation(string stringIn);
    }
}
