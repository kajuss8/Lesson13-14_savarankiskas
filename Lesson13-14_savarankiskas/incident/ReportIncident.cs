using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13_14_savarankiskas.incident
{
    internal class ReportIncident
    {
        public string CameToWorkHumanName { get; set; }
        public int CameToWorkHumanId { get; set; }
        public string CameToWorkGateName { get; set; }
        public int WhenCameToWorkHour { get; set; }
        public int WhenCameToWorkMinute { get; set; }
        public int DidNotWentThroughGates1 { get; set; }
        public int BreakTimeHour { get; set; }
        public int BreakTimeMinute { get; set; }
        public int EndOfBreakHour { get; set; }
        public int EndOfBreakMinute { get; set; }
        public int DidNotWentThroughGates2 { get; set; }
        public int EndOfWorkHour { get; set; }
        public int EndOfWorkMinute { get; set; }
        public int DidNotWentThroughGates3 { get; set; }
        public int OneGateSecond { get; set; }
        public int TwoGateSecond1 { get; set; }
        public int TwoGateSecond2 { get; set; }
        public int ThreeGateSecond1 { get; set; }
        public int ThreeGateSecond2 { get; set; }
        public int ThreeGateSecond3 { get; set; }


        public ReportIncident()
        {

        }
    }
}
