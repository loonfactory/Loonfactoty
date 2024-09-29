using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Loonfactory.OpenWeather.v3_0;

public static class OpenWeatherCollectionExtensions
{
    public static OpenWeatherBuilder AddOpenWeather(this IServiceCollection services, Action<OpenWeatherOptions> configureOptions)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.TryAddScoped<IOpenWeatherHandlerProvider, OpenWeatherHandlerProvider>();
        services.TryAddScoped<IOpenWeatherService, OpenWeatherService>();

        services.TryAddSingleton<ISystemClock, SystemClock>();
        
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }

        services.AddOptions<OpenWeatherOptions>().Validate(o =>
        {
            o.Validate();
            return true;
        });

        return new OpenWeatherBuilder(services);
    }
}
