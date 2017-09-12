using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcInfoModels
{
    [DataContract]
    public class Service
    {
        [DataMember]
        public string Name { get; set; }

        public Service(string name)
        {
            Name = name;
        }
    }
}
