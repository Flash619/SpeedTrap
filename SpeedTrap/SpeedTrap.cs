using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using SpeedTrap.Traps;

namespace SpeedTrap
{
    public class SpeedTrap : ISpeedTrap
    {
        private readonly ConcurrentDictionary<string, ITrap> _trapsByNameDictionary = new();
        public IEnumerable<ITrap> Traps => _trapsByNameDictionary.Values;

        public ITrap GetTrap(Action action)
            => GetTrap(action.Method);

        public ITrap GetTrap<T>(Action<T> action)
            => GetTrap(action.Method);

        public ITrap GetTrap(MemberInfo action)
            => GetTrap(action.Name, action);

        public ITrap GetTrap(string name, Action? action = null)
            => GetTrap(name, action?.Method);
        
        public ITrap GetTrap<T>(string name, Action<T>? action = null)
            => GetTrap(name, action?.Method);
        
        private ITrap GetTrap(string name, MemberInfo? action = null)
        {
            _trapsByNameDictionary.AddOrUpdate(name,
                _ => new Trap(name)
                {
                    Action = action
                } as ITrap,
                (_, existingTrap2) => existingTrap2);
            
            return _trapsByNameDictionary[name];
        }
    }
}