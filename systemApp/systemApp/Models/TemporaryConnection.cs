using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace systemApp.Models
{
    public class TemporaryConnection
    {
        public string IP { get; set; }
        public string Name { get; set; }

        public TemporaryConnection(string ip, string name)
        {
            IP = ip;
            Name = name;
        }

        public TemporaryConnection()
        {
        }
    }
}