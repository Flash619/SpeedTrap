using System;

namespace SpeedTrap.Traps
{
    public interface IRun
    {
        DateTimeOffset StartedOn { get; }
        TimeSpan Duration { get; }
        void Stop();
    }
}