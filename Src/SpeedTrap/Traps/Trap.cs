using System.Collections.Generic;
using System.Reflection;

namespace SpeedTrap.Traps
{
    public class Trap : ITrap
    {
        public string Name { get; }
        public MemberInfo? Action { get; init; }
        public IEnumerable<IRun> Runs => _runs;
        private readonly List<IRun> _runs = new();

        internal Trap(string name)
            => Name = name;

        internal Trap(MemberInfo action)
            => (Name, Action) = (action.Name, action);

        public IRun StartRun()
        {
            var run = new Run();
            _runs.Add(run);
            run.Start();
            return run;
        }
    }
}