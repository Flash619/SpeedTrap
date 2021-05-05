using Microsoft.Extensions.DependencyInjection;

namespace SpeedTrap.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSpeedTrap(this IServiceCollection services)
        {
            services.AddSingleton<ISpeedTrap, SpeedTrap>();
            return services;
        }
    }
}