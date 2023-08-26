using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Loonfactory.DataGoKr;

public static class DataGoKrCollectionExtensions
{
    public static DataGoKrBuilder AddDataGoKr(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.TryAddScoped<IDataGoKrHandlerProvider, DataGoKrHandlerProvider>();

        services.TryAddSingleton<ISystemClock, SystemClock>();
                
        services.TryAddEnumerable(ServiceDescriptor.Scoped<IPostConfigureOptions<DataGoKrOptions>, DataGoKrPostConfigureOptions<DataGoKrOptions>>());

        return new DataGoKrBuilder(services);
    }
}
