using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13_14_savarankiskas.@class
{
    internal class Gate
    {
        public string GateName { get; set; }
        public int GateId { get; set; }

        public Gate(string gateName, int gateId)
        {
            GateName = gateName;
            GateId = gateId;
        } 
    }
}
