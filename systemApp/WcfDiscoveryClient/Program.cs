using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary;

namespace WcfDiscoveryClient
{
    class Program
    {
        class WcfClient
        {
            public static void Main(string[] args)
            {
                System.Threading.Thread.Sleep(4000);
                WcfClient_SetupChannel();
                System.Threading.Thread.Sleep(2000);
                WcfClient_Ping();
            }

            private static IWcfTestMessage channel;

            public static Uri WcfClient_DiscoverChannel()
            {
                var discoveryclient = new DiscoveryClient(new UdpDiscoveryEndpoint());
                FindCriteria findcriteria = new FindCriteria(typeof(IWcfTestMessage));
                findcriteria.Duration = TimeSpan.FromSeconds(5);
                FindResponse findresponse = discoveryclient.Find(findcriteria);
                foreach (EndpointDiscoveryMetadata edm in findresponse.Endpoints)
                {
                    Console.WriteLine("uri found = " + edm.Address.Uri.ToString());
                }
                return findresponse.Endpoints[0].Address.Uri;
            }

            public static void WcfClient_SetupChannel()
            {
                var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                var factory = new ChannelFactory<IWcfTestMessage>(binding);
                var uri = WcfClient_DiscoverChannel();
                Console.WriteLine("creating channel to " + uri.ToString());
                EndpointAddress ea = new EndpointAddress(uri);
                channel = factory.CreateChannel(ea);
                Console.WriteLine("channel created");
            }

            public static void WcfClient_Ping()
            {
                Console.WriteLine("getting message from host");
                string result = channel.Message();
                Console.WriteLine("message result = " + result);
                Console.ReadKey();
            }

        }
    }
}
