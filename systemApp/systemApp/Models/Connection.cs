using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace systemApp.Models
{
    public class Connection
    {
        public string IP { get; set; }
        public string Name { get; set; }

        public Connection(string ip, string name)
        {
            IP = ip;
            Name = name;
        }

        public Connection(string ip)
        {
            IP = ip;
        }

        public Connection()
        {
        }
    }
}