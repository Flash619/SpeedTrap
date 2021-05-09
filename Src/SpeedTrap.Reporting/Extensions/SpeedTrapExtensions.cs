using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeedTrap.Reporting.Extensions
{
    public static class SpeedTrapExtensions
    {
        
        public static Task<IReport> GenerateReport(this ISpeedTrap speedTrap, ReportOptions? options = null)
        {
            options ??= new ReportOptions();
            var report = new Report(options);

            var firstRun = true;

            foreach (var trap in speedTrap.Traps)
            {
                var trapTotalDuration = TimeSpan.Zero;
                var trapRunDetail = new Dictionary<DateTimeOffset, TimeSpan>();
                
                foreach (var run in trap.Runs)
                {
                    if (run.StartedOn < report.FirstTrapRanOn || firstRun)
                    {
                        report.FirstTrapRanOn = run.StartedOn;
                    }

                    if (run.StartedOn > report.LastTrapRanOn || firstRun)
                    {
                        report.LastTrapRanOn = run.StartedOn;
                    }

                    trapTotalDuration = trapTotalDuration.Add(run.Duration);
                    trapRunDetail.Add(run.StartedOn, run.Duration);

                    firstRun = false;
                }

                report.TotalTrackedDuration = report.TotalTrackedDuration.Add(trapTotalDuration);
                report.TrapDuration.Add(trap.Name, trapTotalDuration);
                report.TrapRunDetail.Add(trap.Name, trapRunDetail);
            }

            foreach (var (trap, duration) in report.TrapDuration)
            {
                report.TrapDurationPercentage.Add(trap, Math.Round((double) duration.Ticks / report.TotalTrackedDuration.Ticks * 100, 2));
            }

            return Task.FromResult(report as IReport);
        }
    }
}