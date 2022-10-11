using Lesson13_14_savarankiskas.@class;
using Lesson13_14_savarankiskas.incident;
using Lesson13_14_savarankiskas.WorkTime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Lesson13_14_savarankiskas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GateRepozitory gates = new GateRepozitory();
            HumanRepozitory humans = new HumanRepozitory();
            Incident incident = new Incident(gates, humans);
            var tempIncident = incident.HappendIncident();
            ReportWorkingTime reportTime = new ReportWorkingTime(tempIncident);
            var tempReportTime = reportTime.WorkingTime();
            

            string workTime = @"C:\Users\37067\OneDrive\Desktop\C sharp basic\Lesson13-14_savarankiskas\Lesson13-14_savarankiskas\WorkTime.txt";
            string workers = @"C:\Users\37067\OneDrive\Desktop\C sharp basic\Lesson13-14_savarankiskas\Lesson13-14_savarankiskas\workers.txt";
            File.WriteAllText(workTime, "");
            File.WriteAllText(workers, "");

            int tempSumHour = 0;
            int tempSumMinute = 0;
            foreach (var( report, workingTime) in tempIncident.Zip(tempReportTime))
            {
                
                Console.WriteLine($"Name: {report.CameToWorkHumanName}. " +
                    $"ID: {report.CameToWorkHumanId} enter incorrect gates: {report.DidNotWentThroughGates1} times. " +
                    $"He went through: {report.CameToWorkGateName}. Came to work: {string.Format("{0:00}", report.WhenCameToWorkHour)}:" +
                    $"{string.Format("{0:00}", report.WhenCameToWorkMinute)} Break time: {string.Format("{0:00}", report.BreakTimeHour)}:" +
                    $"{string.Format("{0:00}", report.BreakTimeMinute)} Came from break: {string.Format("{0:00}", report.EndOfBreakHour)}:" +
                    $"{string.Format("{0:00}", report.EndOfBreakMinute)} Ended work: {string.Format("{0:00}", report.EndOfWorkHour)}:" +
                    $"{string.Format("{0:00}", report.EndOfWorkMinute)} worked: {workingTime.WorkingHour}h {workingTime.WorkingMinute}min" +
                    $" break time: {workingTime.ConvertMinToHour}h {workingTime.BreakTimeMinute}min");
                tempSumHour += workingTime.WorkingHour;
                tempSumMinute += workingTime.WorkingMinute;
                Console.WriteLine();
                //txt file workers
                File.AppendAllText(workers, $"Name: {report.CameToWorkHumanName}| " +
                    $"ID: {report.CameToWorkHumanId}|");
                
                if(report.DidNotWentThroughGates1 == 0)
                {
                    File.AppendAllText(workers, $"enter incorrect gates: {report.DidNotWentThroughGates1} times| ");
                }
                else if(report.DidNotWentThroughGates1 == 1)
                {
                    File.AppendAllText(workers, $"enter incorrect gates: {report.DidNotWentThroughGates1} time " +
                    $"{string.Format("{0:00}", report.WhenCameToWorkHour)}:{string.Format("{0:00}", report.WhenCameToWorkMinute-1)}:" +
                    $"{string.Format("{0:00}", report.OneGateSecond)}| ");
                }
                else if(report.DidNotWentThroughGates1 == 2)
                {
                    File.AppendAllText(workers, $"enter incorrect gates: {report.DidNotWentThroughGates1} times" +
                    $" first time: {string.Format("{0:00}", report.WhenCameToWorkHour)}:{string.Format("{0:00}", report.WhenCameToWorkMinute-1)}:" +
                    $"{string.Format("{0:00}", report.TwoGateSecond1)} second time: {string.Format("{0:00}", report.WhenCameToWorkHour)}" +
                    $":{string.Format("{0:00}", report.WhenCameToWorkMinute - 1)}:{string.Format("{0:00}", report.TwoGateSecond2)}| ");
                }
                else if(report.DidNotWentThroughGates1 == 3)
                {
                    File.AppendAllText(workers, $"enter incorrect gates: {report.DidNotWentThroughGates1} times" +
                    $" first time {string.Format("{0:00}", report.WhenCameToWorkHour)}:{string.Format("{0:00}", report.WhenCameToWorkMinute-1)}:" +
                    $"{string.Format("{0:00}", report.ThreeGateSecond1)} second time {string.Format("{0:00}", report.WhenCameToWorkHour)}:" +
                    $"{string.Format("{0:00}", report.WhenCameToWorkMinute - 1)}:{string.Format("{0:00}", report.ThreeGateSecond2)}" +
                    $" third time {string.Format("{0:00}", report.WhenCameToWorkHour)}:{string.Format("{0:00}", report.WhenCameToWorkMinute - 1)}:" +
                    $"{string.Format("{0:00}", report.ThreeGateSecond3)}| ");
                }
                File.AppendAllText(workers, $"He went through: {report.CameToWorkGateName}| Came to work: {string.Format("{0:00}", report.WhenCameToWorkHour)}:" +
                    $"{string.Format("{0:00}", report.WhenCameToWorkMinute)}\n");


                //txt file WorkTime
                File.AppendAllText(workTime, $"Name: {report.CameToWorkHumanName}| " +
                    $"ID: {report.CameToWorkHumanId}| Came to work: {string.Format("{0:00}", report.WhenCameToWorkHour)}:" +
                    $"{string.Format("{0:00}", report.WhenCameToWorkMinute)}| Break time: {string.Format("{0:00}", report.BreakTimeHour)}:" +
                    $"{string.Format("{0:00}", report.BreakTimeMinute)}| Came from break: {string.Format("{0:00}", report.EndOfBreakHour)}:" +
                    $"{string.Format("{0:00}", report.EndOfBreakMinute)}| Ended work: {string.Format("{0:00}", report.EndOfWorkHour)}:" +
                    $"{string.Format("{0:00}", report.EndOfWorkMinute)}| worked: {workingTime.WorkingHour}h {workingTime.WorkingMinute}min" +
                    $"| break time: {workingTime.ConvertMinToHour}h {workingTime.BreakTimeMinute}min \n");
            }
            while(tempSumMinute > 59)
            {
                tempSumMinute -= 60;
                tempSumHour++;
            }
            Console.WriteLine($"All workers spend: {tempSumHour}h and {tempSumMinute}min in work");
            File.AppendAllText(workTime, $"All workers spend: {tempSumHour}h and {tempSumMinute}min in work");


            /*
            for (int i = 0; i < x.Count; i++)
            {
                Console.WriteLine($"Name: {x[i].CameToWorkHumanName}. " +
                   $"ID: {x[i].CameToWorkHumanId} enter incorrect gates: {x[i].DidNotWentThroughGates1} times. " +
                   $"He went through: {x[i].CameToWorkGateName}. Came to work: {string.Format("{0:00}", x[i].WhenCameToWorkHour)}:" +
                   $"{string.Format("{0:00}", x[i].WhenCameToWorkMinute)} Break time: {string.Format("{0:00}", x[i].BreakTimeHour)}:" +
                   $"{string.Format("{0:00}", x[i].BreakTimeMinute)} Came from break: {string.Format("{0:00}", x[i].EndOfBreakHour)}:" +
                   $"{string.Format("{0:00}", x[i].EndOfBreakMinute)} Ended work: {string.Format("{0:00}", x[i].EndOfWorkHour)}:" +
                   $"{string.Format("{0:00}", x[i].EndOfWorkMinute)} {y[i].WorkingHour} {y[i].ConvertMinToHour}:{y[i].WorkingMinute}");
                Console.WriteLine();
            }
            */


        }
    }
}
