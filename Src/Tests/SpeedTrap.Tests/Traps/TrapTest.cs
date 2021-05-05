using System.Linq;
using Xunit;

namespace SpeedTrap.Tests.Traps
{
    public class TrapTests
    {
        [Fact]
        public void TrapRetainsRunRecords()
        {
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap(TrapIsNotReplacedPerGet);
            var run = trap.StartRun();
            run.Stop();
            Assert.NotEmpty(trap.Runs);
            Assert.Equal(run.Duration, trap.Runs.First().Duration);
            Assert.Equal(run.StartedOn, trap.Runs.First().StartedOn);
        }
        
        [Fact]
        public void TrapIsNotReplacedPerGet()
        {
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap(TrapIsNotReplacedPerGet);
            var run = trap.StartRun();
            run.Stop();
            Assert.NotEmpty(trap.Runs);
            trap = speedTrap.GetTrap(TrapIsNotReplacedPerGet);
            Assert.NotEmpty(trap.Runs);
        }
    }
}