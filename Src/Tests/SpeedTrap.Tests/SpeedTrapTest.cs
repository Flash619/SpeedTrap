using System.Linq;
using Xunit;

namespace SpeedTrap.Tests
{
    public class SpeedTrapTest
    {
        [Fact]
        public void SpeedTrapInstantiates()
        {
            var speedTrap = new SpeedTrap();
            Assert.NotNull(speedTrap);
            Assert.Empty(speedTrap.Traps);
        }
        
        [Fact]
        public void SpeedTrapRetainsTrapRecords()
        {
            var speedTrap = new SpeedTrap();
            Assert.NotNull(speedTrap);
            Assert.Empty(speedTrap.Traps);
            var trap = speedTrap.GetTrap(SpeedTrapRetainsTrapRecords);
            Assert.NotEmpty(speedTrap.Traps);
            Assert.Equal(trap.Name, speedTrap.Traps.First().Name);
            Assert.Equal(trap.Action, speedTrap.Traps.First().Action);
        }
        
        [Fact]
        public void SpeedTrapReturnsAccurateTapNameByString()
        {
            const string trapName = "trap1";
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap(trapName);
            Assert.NotEmpty(speedTrap.Traps);
            Assert.Equal(trapName, trap.Name);
            Assert.Null(trap.Action);
        }
        
        [Fact]
        public void SpeedTrapReturnsAccurateTapNameByAction()
        {
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap(SpeedTrapReturnsAccurateTapNameByAction);
            Assert.NotEmpty(speedTrap.Traps);
            Assert.Equal(nameof(SpeedTrapReturnsAccurateTapNameByAction), trap.Name);
            Assert.NotNull(trap.Action);
        }
        
        [Fact]
        public void SpeedTrapReturnsAccurateTapNameByNameWithAction()
        {
            const string trapName = "trap1";
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap(trapName, SpeedTrapReturnsAccurateTapNameByNameWithAction);
            Assert.NotEmpty(speedTrap.Traps);
            Assert.Equal(trapName, trap.Name);
            Assert.NotNull(trap.Action);
        }
    }
}