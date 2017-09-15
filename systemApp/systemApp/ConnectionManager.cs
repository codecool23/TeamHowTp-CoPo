using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;
using WcfDiscoveryClient;

namespace systemApp
{
    public class ConnectionManager
    {
        public static List<Models.Connection> connectionList = new List<Models.Connection>();
        public static List<Uri> allUri = new List<Uri>();

        public static void getAllUri() {
            foreach (var x in WcfClient.WcfClient_DiscoverChannel()){
                allUri.Add(x);
                connectionList.Add(new Models.Connection() { IP = x.ToString() });
            }
        }   
    }
}