using System;
using System.Linq;
using System.Threading.Tasks;
using SpeedTrap.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace SpeedTrap.Tests.Traps
{
    public class TrapTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TrapTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TrapRunWorksWithAction()
        {
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap("test-trap");
            trap.Run(() => _testOutputHelper.WriteLine("Hello World!"));
            Assert.NotNull(trap.LastRun);
            Assert.NotEqual(TimeSpan.Zero, trap.LastRun?.Duration);
        }
        
        [Fact]
        public void TrapRunsWithBlockingFunc()
        {
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap("test-trap");
            var number = trap.Run(() => 12345);
            Assert.NotNull(trap.LastRun);
            Assert.NotEqual(TimeSpan.Zero, trap.LastRun?.Duration);
            Assert.Equal(12345, number);
        }
        
        [Fact]
        public async Task TrapRunsWithAsyncFunc()
        {
            var speedTrap = new SpeedTrap();
            var trap = speedTrap.GetTrap("test-trap");
            var number = await trap.Run(() => Task.FromResult(12345));
            Assert.NotNull(trap.LastRun);
            Assert.NotEqual(TimeSpan.Zero, trap.LastRun?.Duration);
            Assert.Equal(12345, number);
        }
    }
}