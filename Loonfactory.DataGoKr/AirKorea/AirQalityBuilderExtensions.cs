using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Loonfactory.DataGoKr.AirKorea;

public static class AirQalityBuilderExtensions
{
    public static DataGoKrBuilder AddAirPollution(this DataGoKrBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.Services.TryAddScoped<IAirQalityInquiryService, AirQalityInquiryService>();
        return builder;
    }
}
