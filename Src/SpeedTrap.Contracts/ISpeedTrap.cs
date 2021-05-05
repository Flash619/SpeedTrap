using System;
using System.Collections.Generic;
using System.Reflection;
using SpeedTrap.Traps;

namespace SpeedTrap
{
    public interface ISpeedTrap
    {
        IEnumerable<ITrap> Traps { get; }
        ITrap GetTrap(Action action);
        ITrap GetTrap<T>(Action<T> action);
        ITrap GetTrap(string name, Action? action = null);
        ITrap GetTrap<T>(string name, Action<T>? action = null);
    }
}