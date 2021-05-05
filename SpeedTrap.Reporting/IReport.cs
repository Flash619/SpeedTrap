using System;
using System.Collections.Generic;

namespace SpeedTrap.Reporting
{
    public interface IReport
    {
        public string Name { get; }
        public string Description { get; }
        public string Version { get; }
        public string QuickestTrap { get; }
        public string SlowestTrap { get; }
        public DateTimeOffset FirstTrapRanOn { get; }
        public DateTimeOffset LastTrapRanOn { get; }
        public TimeSpan TotalTrackedDuration { get; }
        public IDictionary<string, double> TrapDurationPercentage { get; }
        public IDictionary<string, TimeSpan> TrapDuration { get; }
        public IDictionary<string, int> TrapCallTotal { get; }
        public IDictionary<string,  IDictionary<DateTimeOffset, TimeSpan>> TrapRunDetail { get; }
    }
}