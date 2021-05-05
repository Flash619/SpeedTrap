namespace SpeedTrap.Reporting
{
    public class ReportOptions
    {
        public string Name { get; init; } = "SpeedTrap Report";
        public string Description { get; init; } = "Showing where speed was lost.";
        public string Version { get; init; } = "v1.0";
        public bool IncludeCharts { get; init; } = true;
    }
}