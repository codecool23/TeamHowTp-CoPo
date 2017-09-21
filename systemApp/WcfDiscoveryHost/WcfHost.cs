using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.ServiceModel.Description;
using System.Net;
using PcInfoSenderService;

namespace WcfDiscoveryHost
{

    class WcfHost
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            
            WcfHost_Open();
            log.Info("Opening wcf host");
            log.Info("Endpoint listening enabled");
            log.Info("Enable wsd1");
            log.Info("Creating endpoint");
            log.Info("Sending Pc information");
            log.Info("Enable process kill function for admin users");
            Console.ReadKey();
        }

        public static void WcfHost_Open()
        {
            log.Debug("host open");
            string hostname = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            var baseAddress = new UriBuilder("http", hostname, 8000, "PcInfoSender");
            var host = new ServiceHost(typeof(PcInfoSenderService.PcInfoSender), baseAddress.Uri);

            // enable processing of discovery messages.  use UdpDiscoveryEndpoint to enable listening. use EndpointDiscoveryBehavior for fine control.
            host.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
            host.AddServiceEndpoint(new UdpDiscoveryEndpoint());

            // enable wsdl, so you can use the service from WcfStorm, or other tools.
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(smb);

            // create endpoint
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            binding.MaxReceivedMessageSize = 4294967295;
            binding.TransferMode = TransferMode.Streamed;
            host.AddServiceEndpoint(typeof(PcInfoSenderService.IPcInfoSender), binding, "");
            host.Open();
            Console.WriteLine("host open at " + baseAddress);
        }
    }
}
