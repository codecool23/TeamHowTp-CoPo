using PcInfoModels;
using PcInfoSenderService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace WcfDiscoveryClient
{
    public class WcfClient
    {
        public static void Main(string[] args)
        {
            WcfClient_SetupChannel();

            // We can use our WCF service methods as follows:
            List<PcInfoModels.Process> p = channel.GetAllProcess();
            List<Service> s = channel.GetAllServices();
            RuntimeInfo r = channel.GetRuntimeInformation();
            List<DiskSpace> d = channel.GetDeviceInformation();
        }

        private static PcInfoSenderService.IPcInfoSender channel;

        public static async Task<List<Uri>> WcfClient_DiscoverChannel()
        {
            List<Uri> allUri = new List<Uri>();
            var discoveryclient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindCriteria findcriteria = new FindCriteria(typeof(PcInfoSenderService.IPcInfoSender));
            findcriteria.Duration = TimeSpan.FromSeconds(5);
            FindResponse findresponse = discoveryclient.Find(findcriteria);
            foreach (EndpointDiscoveryMetadata edm in findresponse.Endpoints)
            {
                allUri.Add(edm.Address.Uri);
            }
            //systemApp.ConnectionManager.allUri = allUri;
            return allUri;
        }

        public static async void WcfClient_SetupChannel()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            binding.MaxReceivedMessageSize = 4294967295;
            binding.TransferMode = TransferMode.Streamed;
           
            var factory = new ChannelFactory<PcInfoSenderService.IPcInfoSender>(binding);
            var allUri = await WcfClient_DiscoverChannel();
            EndpointAddress ea = new EndpointAddress(allUri[0]);
            channel = factory.CreateChannel(ea);
            Console.WriteLine("channel created");
        }
    }
}

