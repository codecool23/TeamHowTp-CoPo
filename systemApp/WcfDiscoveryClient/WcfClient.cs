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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main()
        {
            log.Info("Hello logging world!");
            Console.WriteLine("Hit enter");
            Console.ReadLine();
        }

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

        public static IPcInfoSender WcfClient_SetupChannel(string IP)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            binding.MaxReceivedMessageSize = 4294967295;
            binding.TransferMode = TransferMode.Streamed;
           
            var factory = new ChannelFactory<PcInfoSenderService.IPcInfoSender>(binding);
            EndpointAddress ea = new EndpointAddress(IP);
            return factory.CreateChannel(ea);
        }
    }
}

