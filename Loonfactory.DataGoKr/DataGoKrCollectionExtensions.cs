using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Loonfactory.DataGoKr;

public static class DataGoKrCollectionExtensions
{
    public static DataGoKrBuilder AddDataGoKr<TOptions>(this IServiceCollection services) where TOptions : DataGoKrOptions, new()
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.TryAddScoped<IDataGoKrHandlerProvider<DataGoKrOptions>, DataGoKrHandlerProvider<DataGoKrOptions>>();
        services.TryAddSingleton<ISystemClock, SystemClock>();
        return new DataGoKrBuilder(services);
    }
}
