using VibeBusWeb.Services;

namespace VibeBusWeb.DependencyInjection;

public static class WebClientServiceCollectionExtensions
{
    public static IServiceCollection AddWebClientServiceCollection(this IServiceCollection services)
    {
        services.AddScoped<BusService>();
        services.AddScoped<CityService>();
        services.AddScoped<DriverService>();
        services.AddScoped<RouteService>();
        services.AddScoped<TripService>();
        services.AddScoped<UserService>();

        return services;
    }
}