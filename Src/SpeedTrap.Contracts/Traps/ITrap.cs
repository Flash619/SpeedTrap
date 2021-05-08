using System.Collections.Generic;
using System.Reflection;

namespace SpeedTrap.Traps
{
    public interface ITrap
    {
        string Name { get; }
        MemberInfo? Action { get; } 
        IEnumerable<IRun> Runs { get; }
        IRun? LastRun { get; }
        public IRun StartRun();
    }
}