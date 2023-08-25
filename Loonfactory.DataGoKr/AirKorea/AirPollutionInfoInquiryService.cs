using System.Text.Json;

namespace Loonfactory.DataGoKr.AirKorea;

public class AirPollutionInfoInquiryService : IAirPollutionInfoInquiryService
{
    private readonly IDataGoKrHandlerProvider<DataGoKrOptions> _handlerProvider;

    public AirPollutionInfoInquiryService(IDataGoKrHandlerProvider<DataGoKrOptions> handlerProvider)
    {
        _handlerProvider = handlerProvider;
    }

    public async ValueTask<AirInfoByProvinceResponse> GetAirInfoByProvinceAsync(AirPollutionInfoByProvinceProperties properties)
    {
        var handle = await _handlerProvider.GetHandlerAsync();
        ArgumentNullException.ThrowIfNull(handle, nameof(handle));

        var result = await handle.GetAsync(
            AirPollutionInfoInquiryServiceEndpoint.AirPollutionInfoByProvinceEndpoint,
            new Dictionary<string, string?>()
            {
                {nameof(handle.Options.ServiceKey), handle.Options.ServiceKey },
                {nameof(properties.PageNo), properties.PageNo?.ToString() },
                {nameof(properties.ReturnType), properties.ReturnType?.ToString() },
                {nameof(properties.NumOfRows), properties.NumOfRows?.ToString() },
                {nameof(properties.PageNo), properties.PageNo?.ToString() },
                {nameof(properties.SidoName), properties.SidoName.ToString() },
                {nameof(properties.Ver), properties.Ver?.ToString() },
            });


        return (await JsonSerializer.DeserializeAsync<AirInfoByProvinceResponse>(
            await result.Content.ReadAsStreamAsync()))!;
    }
}
