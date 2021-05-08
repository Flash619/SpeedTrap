# SpeedTrap
Speed trap is a simple extensible profiling library. By using Traps, you can track how fast various portions of code execute, as well as how often they are executed.

## Examples
### A Simple Example
```c#
var speedTrap = new SpeedTrap();
var trap = speedTrap.GetTrap("hello-world");

trap.Run(() => Console.WriteLine("Hello world!"));

Console.WriteLine($"Hello world executed in {trap.LastRun.Duration.Ticks} ticks!");
```

### A Complicated Example
```c#
public static void HelloWorld()
    => Console.WriteLine("Hello world!");

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

### A Complicated Example With Fluent Design
```c#
public static void HelloWorld()
    => Console.WriteLine("Hello world!");

var speedTrap = new SpeedTrap();
var trap = speedTrap.GetTrap(HelloWorld);
var tasks = new List<Task>();

for (var i = 0; i < 100; i++)
{
    tasks.Add(trap.Run(() => {
        HelloWorld();
        return Task.CompletedTask;
    }));
}

await Task.WhenAll(tasks);

var totalDuration = TimeSpan.Zero;

foreach (var run in trap.Runs)
{
    totalDuration = totalDuration.Add(run.Duration);
}

Console.WriteLine($"{trap.Name} trap ran {trap.Runs.Count()} times totalling {totalDuration.Ticks} ticks!");
```