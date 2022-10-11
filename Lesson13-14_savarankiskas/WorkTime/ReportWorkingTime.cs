using Lesson13_14_savarankiskas.incident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13_14_savarankiskas.WorkTime
{
    internal class ReportWorkingTime
    {
        Incident incident;
        List<ReportIncident> Report;
        public ReportWorkingTime(Incident _incident)
        {
            incident = _incident;
        }
        public ReportWorkingTime(List<ReportIncident> report)
        {
            Report = report;
        }
       public List<ReportWorkingTimeHourAndMinute> WorkingTime()
        {
            List<ReportWorkingTimeHourAndMinute> hours = new List<ReportWorkingTimeHourAndMinute>();
            int tempHour = 0;
            int tempMin = 0;
            
            foreach (var incidentTime in Report)
            {
                //break time variable
                int tempBreakTimeHour = incidentTime.BreakTimeHour;
                int tempEndOfBreakHour = incidentTime.EndOfBreakHour;
                int tempEndOfBreakMinute = incidentTime.EndOfBreakMinute;
                int tempBreakTimeMinute = incidentTime.BreakTimeMinute;
                //first half variable
                int countWhenCameToWorkMinute = incidentTime.WhenCameToWorkMinute;
                int countBreakTimeMinute = incidentTime.BreakTimeMinute;
                //second half variable
                int countEndOfBreakMinute = incidentTime.EndOfBreakMinute;
                int countEndOfWorkMinute = incidentTime.EndOfWorkMinute;

                ReportWorkingTimeHourAndMinute sumHour = new ReportWorkingTimeHourAndMinute();
                //First half count
                int tempSumFirstHour = (incidentTime.BreakTimeHour - incidentTime.WhenCameToWorkHour);
                int tempSumFirstMinute = 0;
                while (countWhenCameToWorkMinute != countBreakTimeMinute)
                {
                    tempSumFirstMinute++;
                    countWhenCameToWorkMinute += 1;
                    if (countWhenCameToWorkMinute == 60)
                    {
                        countWhenCameToWorkMinute = 0;
                        tempSumFirstHour -= 1;

                    }
                }

                //Second half count
                int tempSumSecondHour = (incidentTime.EndOfWorkHour - incidentTime.EndOfBreakHour);
                int tempSumSecondMinute = 0;
                while (countEndOfBreakMinute != countEndOfWorkMinute)
                {
                    tempSumSecondMinute++;
                    countEndOfBreakMinute += 1;
                    if (countEndOfBreakMinute == 60)
                    {
                        countEndOfBreakMinute = 0;
                        tempSumSecondHour -= 1;

                    }
                }
                // sum first half and second half
                int tempAllSumHour = tempSumFirstHour + tempSumSecondHour;
                int tempAllSumMinute = tempSumSecondMinute + tempSumFirstMinute;
                if (tempAllSumMinute > 59)
                {
                    tempAllSumMinute -= 60;
                    tempAllSumHour++;
                }

                //Break time count
                while (tempBreakTimeHour != tempEndOfBreakHour)
                {

                    tempBreakTimeHour += 1;
                    tempHour++;
                    
                }
                while(tempEndOfBreakMinute != tempBreakTimeMinute)
                {
                    tempMin++;
                    tempBreakTimeMinute += 1;
                    if (tempBreakTimeMinute == 60)
                    {
                        tempBreakTimeMinute = 0;
                        tempHour -= 1;
                            
                    }
                }



                sumHour.WorkingHour = tempAllSumHour;
                sumHour.WorkingMinute = tempAllSumMinute;
                sumHour.ConvertMinToHour = tempHour;
                sumHour.BreakTimeMinute = tempMin;
                hours.Add(sumHour);
                tempHour = 0;
                tempMin = 0;
                tempSumFirstHour = 0;
                tempSumFirstMinute = 0;
                tempSumSecondHour = 0;
                tempSumSecondMinute = 0;
                
            }

            return hours;
        }


    }
}
