using System.Linq;
using Xunit;

namespace SpeedTrap.Tests.Traps
{
    public class TrapTests
    {
        [Fact]
        public void TrapOperatesAsExpected()
        {
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap(TrapOperatesAsExpected);
            var run = trap.StartRun();
            
            Assert.True(run.IsRunning);
            
            run.Stop();
            
            Assert.False(run.IsRunning);
            Assert.NotEmpty(trap.Runs);
            Assert.NotNull(trap.LastRun);
            Assert.Equal(trap.LastRun, trap.Runs.Last());
            Assert.Equal(run.Duration, trap.Runs.First().Duration);
            Assert.Equal(run.StartedOn, trap.Runs.First().StartedOn);
        }
        
        [Fact]
        public void TrapIsNotReplacedPerGetTrapCall()
        {
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap(TrapIsNotReplacedPerGetTrapCall);
            var run = trap.StartRun();
            run.Stop();
            Assert.NotEmpty(trap.Runs);
            trap = speedTrap.GetTrap(TrapIsNotReplacedPerGetTrapCall);
            Assert.NotEmpty(trap.Runs);
        }
    }
}