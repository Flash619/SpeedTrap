using System;
using System.Diagnostics;

namespace SpeedTrap.Traps
{
    public class Run : IRun
    {
        public DateTimeOffset StartedOn { get; }
        public TimeSpan Duration => _stopwatch.Elapsed;
        private readonly Stopwatch _stopwatch;

        internal Run()
            => (StartedOn, _stopwatch) = (DateTimeOffset.Now, new Stopwatch());

        internal void Start()
        {
            _stopwatch.Start();
        }
        
        public void Stop()
        {
            _stopwatch.Stop();
        }
    }
}