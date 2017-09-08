using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;

namespace systemApp
{
    public class ConnectionManager
    {
        public static List<Models.TemporaryConnection> connectionList = new List<Models.TemporaryConnection>
        {
           new Models.TemporaryConnection(){IP = "192.168.161.133", Name = "John"},
           new Models.TemporaryConnection(){IP = "192.168.161.134", Name = "George"},
           new Models.TemporaryConnection(){IP = "192.168.161.135", Name = "Paul"},
           new Models.TemporaryConnection(){IP = "192.168.161.136", Name = "Ringo"},
        };
    }
}