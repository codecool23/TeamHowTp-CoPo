using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;
using WcfDiscoveryClient;
using System.Threading.Tasks;

namespace systemApp
{
    public class ConnectionManager
    {
        public static List<Models.Connection> connectionList = new List<Models.Connection>();

        public static async Task GetAllUri() {
            connectionList.Clear();
            var allConnections = await WcfClient.WcfClient_DiscoverChannel();
            foreach (var x in allConnections){
                connectionList.Add(new Models.Connection(x.ToString()));
            }
        }   
    }
}