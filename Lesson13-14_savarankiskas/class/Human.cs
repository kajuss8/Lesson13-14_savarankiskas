using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13_14_savarankiskas.@class
{
    internal class Human
    {

        public string Name { get; set; }
        public int HumanId { get; set; }
        public int Incident { get; set; }
        public int GateId { get; set; }

        public Human(string name, int humanId, int incident, int gateId)
        {
            Name = name;
            HumanId = humanId;
            Incident = incident;
            GateId = gateId;
        }


    }
}
