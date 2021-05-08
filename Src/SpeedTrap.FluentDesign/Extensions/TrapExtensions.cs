using System;
using System.Threading.Tasks;
using SpeedTrap.Traps;

namespace SpeedTrap.Extensions
{
    public static class TrapExtensions
    {
        public static void Run(this ITrap trap, Action action)
        {
            var run = trap.StartRun();
            action();
            run.Stop();
        }
        
        public static async Task<T> Run<T>(this ITrap trap, Func<Task<T>> func)
        {
            var run = trap.StartRun();
            var returnValue = await func();
            run.Stop();
            return returnValue;
        }
        
        public static T Run<T>(this ITrap trap, Func<T> func)
        {
            var run = trap.StartRun();
            var returnValue = func();
            run.Stop();
            return returnValue;
        }
    }
}