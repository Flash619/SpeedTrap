using System;

namespace SpeedTrap.Traps
{
    public interface IRun
    {
        bool IsRunning { get; }
        DateTimeOffset StartedOn { get; }
        TimeSpan Duration { get; }
        void Stop();
    }
}