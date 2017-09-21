using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PcInfoModels
{
    [DataContract]
    public class Process
    {
        [DataMember]
        public string ProcessName { get; set; }
        [DataMember]
        public int Id { get; set; }

        public Process(string pName, int id)
        {
            ProcessName = pName;
            Id = id;
        }
    }
}
