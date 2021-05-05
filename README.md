# SpeedTrap
Speed trap is a simple extensible profiling library. By using Traps, you can track how fast various portions of code execute, as well as how often they are executed.

## Exmples
### A Simple Example
```c#
var speedTrap = new SpeedTrap();
var trap = speedTrap.GetTrap("hello-world");
var run = trap.StartRun();

Console.WriteLine("Hello World!");

run.Stop();

Console.WriteLine($"Hello world executed in {run.Duration.Ticks} ticks!");
```

### A Complicated Example
```c#
public static void HelloWorld()
    => Console.WriteLine("Hello World!");

var speedTrap = new SpeedTrap();
var trap = speedTrap.GetTrap(HelloWorld);

for (var i = 0; i < 100; i++)
{
    var run = trap.StartRun();
    HelloWorld();
    run.Stop();
}

var totalDuration = TimeSpan.Zero;

foreach (var run in trap.Runs)
{
    totalDuration = totalDuration.Add(run.Duration);
}

Console.WriteLine($"{trap.Name} trap ran {trap.Runs.Count()} times totalling {totalDuration.Ticks} ticks!");
```