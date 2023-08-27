using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Loonfactory.OpenWeather.v3_0;

public static class OpenWeatherCollectionExtensions
{
    public static OpenWeatherBuilder AddOpenWeather(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.TryAddScoped<IOpenWeatherHandlerProvider, OpenWeatherHandlerProvider>();
        services.TryAddScoped<IOpenWeatherService, OpenWeatherService>();

        services.TryAddSingleton<ISystemClock, SystemClock>();

        services.TryAddEnumerable(ServiceDescriptor.Scoped<IPostConfigureOptions<OpenWeatherOptions>, OpenWeatherPostConfigureOptions<OpenWeatherOptions>>());

        return new OpenWeatherBuilder(services);
    }
}
