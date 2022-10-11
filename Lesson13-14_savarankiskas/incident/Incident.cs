using Lesson13_14_savarankiskas.@class;
using Lesson13_14_savarankiskas.incident;
using Lesson13_14_savarankiskas.WorkTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13_14_savarankiskas
{
    internal class Incident
    {
        GateRepozitory gateRepozitory;
        HumanRepozitory humanRepozitory;
        public Incident(GateRepozitory _gateRepozitory, HumanRepozitory _humanRepozitory)
        {
            gateRepozitory = _gateRepozitory;
            humanRepozitory = _humanRepozitory;
        }

        public List<ReportIncident> HappendIncident()
        {

            List<Human> allHuman = humanRepozitory.Retrieve();
            List<Gate> gates = gateRepozitory.Retrieve();
            List<ReportIncident> reportIncident = new List<ReportIncident>();
            Random randomHour = new Random();
            Random randomMinute = new Random();
            Random randomSecond = new Random();

            int failled = 0;
            foreach (var human in allHuman)
            {
                
                foreach (var gate in gates)
                {
                    
                    if (human.GateId == gate.GateId)
                    {
                        ReportIncident report = new ReportIncident();
                        int comeToWorkHour = randomHour.Next(8,10);
                        int comeToWorkMinute = randomMinute.Next(0, 60);
                        int breakHour = randomHour.Next(11, 13);
                        int breakMinute = randomMinute.Next(0, 60);
                        int endOfBreakHour = randomHour.Next(13, 14);
                        int endOfBreakMinute = randomMinute.Next(0, 60);
                        int endOfWorkHour = randomHour.Next(16, 19);
                        int endOfWorkMinute = randomMinute.Next(0, 60);
                        int firstGateSecond = randomSecond.Next(0, 45);
                        int secondGateSecond1 = randomSecond.Next(0, 27);
                        int secondGateSecond2 = randomSecond.Next(36, 53);
                        int thirdGateSecond1 = randomSecond.Next(0, 16);
                        int thirdGateSecond2 = randomSecond.Next(20, 36);
                        int thirdGateSecond3 = randomSecond.Next(46, 60);

                        report.ThreeGateSecond1 = thirdGateSecond1;
                        report.ThreeGateSecond2 = thirdGateSecond2;
                        report.ThreeGateSecond3 = thirdGateSecond3;
                        report.TwoGateSecond1 = secondGateSecond1;
                        report.TwoGateSecond2 = secondGateSecond2;
                        report.OneGateSecond = firstGateSecond;
                        report.CameToWorkHumanName = human.Name;
                        report.CameToWorkHumanId = human.HumanId;
                        report.CameToWorkGateName = gate.GateName;
                        report.WhenCameToWorkHour = comeToWorkHour;
                        report.WhenCameToWorkMinute = comeToWorkMinute;
                        report.BreakTimeHour = breakHour;
                        report.BreakTimeMinute = breakMinute;
                        report.EndOfBreakHour = endOfBreakHour;
                        report.EndOfBreakMinute = endOfBreakMinute;
                        report.EndOfWorkHour = endOfWorkHour;
                        report.EndOfWorkMinute = endOfWorkMinute;
                        report.DidNotWentThroughGates1 = failled;
                       
                        reportIncident.Add(report);
                        
                        failled = 0;
                        break;
                    }
                    else if(human.GateId != gate.GateId)
                    {
                        
                        failled++;
                    }
                    

                }
                
            }
            //reportIncident.Sort((x, y) => string.Compare(x.CameToWorkHumanName, y.CameToWorkHumanName));
            //reportIncident.OrderBy(s => s.CameToWorkHumanName).ThenBy(s => s.WhenCameToWorkHour).ThenBy(s => s.WhenCameToWorkMinute).ToList();
            return reportIncident.OrderBy(s => s.CameToWorkHumanName).ThenBy(s => s.WhenCameToWorkHour).ThenBy(s => s.WhenCameToWorkMinute).ToList();
        }

    }
}
