using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.Unicode;
using System.Threading;

namespace Loonfactory.DataGoKr.AirKorea;

public class AirPollutionInfoInquiryService : IAirPollutionInfoInquiryService
{
    private readonly IDataGoKrHandlerProvider _handlerProvider;

    public AirPollutionInfoInquiryService(IDataGoKrHandlerProvider handlerProvider)
    {
        _handlerProvider = handlerProvider;
    }

    public ValueTask<AirInfoByProvinceResponse> GetAirInfoByProvinceAsync(AirPollutionInfoByProvinceProperties properties)
    {
        return GetAirInfoByProvinceAsync(properties, CancellationToken.None);
    }

    public async ValueTask<AirInfoByProvinceResponse> GetAirInfoByProvinceAsync(AirPollutionInfoByProvinceProperties properties, CancellationToken token)
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
                {nameof(properties.SidoName), properties.SidoName.ToString() },
                {nameof(properties.Ver), properties.Ver?.ToString() },
            },
            token);

        result.EnsureSuccessStatusCode();

        var jsonOption = new JsonSerializerOptions
        {
            Converters = { new AirKoeraJsonConverter() },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        
        return (await result.Content.ReadFromJsonAsync<AirInfoByProvinceResponse>(jsonOption, cancellationToken: token))!;
    }
}


[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(AirInfoByProvinceResponse))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}