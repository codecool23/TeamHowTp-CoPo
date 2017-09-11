using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.ServiceModel.Description;
using System.Net;
using WcfLibrary;

namespace WcfDiscoveryHost
{

    class WcfHost
    {
        public static void Main(string[] args)
        {
            WcfHost_Open();
            Console.ReadKey();
        }

        public static void WcfHost_Open()
        {
            string hostname = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            var baseAddress = new UriBuilder("http", hostname, 2000, "WcfTestMessage");
            var host = new ServiceHost(typeof(WcfTestMessage), baseAddress.Uri);

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
            host.AddServiceEndpoint(typeof(IWcfTestMessage), binding, "");
            host.Open();
            Console.WriteLine("host open at " + baseAddress);
        }
    }
}
