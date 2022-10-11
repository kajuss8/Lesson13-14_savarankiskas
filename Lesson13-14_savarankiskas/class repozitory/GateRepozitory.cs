using Lesson13_14_savarankiskas.@class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13_14_savarankiskas
{
    internal class GateRepozitory
    {
        public List<Gate> Gates { get; set; }

        public GateRepozitory()
        {
            Gates = new List<Gate>();
            Gates.Add(new Gate("First gate", 1));
            Gates.Add(new Gate("Second gate", 2));
            Gates.Add(new Gate("Third gate", 3));
            Gates.Add(new Gate("Fourth gate", 4));
        }
        public List<Gate> Retrieve()
        {
            return Gates;
        }
        public Gate Retrieve(int gateId)
        {
            return Gates.Where(c => c.GateId == gateId).FirstOrDefault();
        }
    }
}
