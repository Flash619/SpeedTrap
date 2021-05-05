using System;
using System.Collections;
using System.Collections.Generic;

namespace SpeedTrap.Reporting
{
    internal class Report : IReport
    {
        public string Name { get; }
        public string Description { get; }
        public string Version { get; }
        public string QuickestTrap { get; set; } = string.Empty;
        public string SlowestTrap { get; set; } = string.Empty;
        public DateTimeOffset FirstTrapRanOn { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset LastTrapRanOn { get; set; } = DateTimeOffset.Now;
        public TimeSpan TotalTrackedDuration { get; set; } = TimeSpan.Zero;
        public IDictionary<string, double> TrapDurationPercentage { get; } = new Dictionary<string, double>();
        public IDictionary<string, TimeSpan> TrapDuration { get; } = new Dictionary<string, TimeSpan>();
        public IDictionary<string, int> TrapCallTotal { get; } = new Dictionary<string, int>();
        public IDictionary<string, IDictionary<DateTimeOffset, TimeSpan>> TrapRunDetail { get; } = new Dictionary<string, IDictionary<DateTimeOffset, TimeSpan>>();

        public Report(ReportOptions options)
            => (Name, Description, Version) = (options.Name, options.Description, options.Version);
    }
}