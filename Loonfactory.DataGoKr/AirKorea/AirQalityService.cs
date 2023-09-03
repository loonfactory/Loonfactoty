using System.Data;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Loonfactory.DataGoKr.AirKorea;

public class AirQalityService : IAirQalityInquiryService
{
    private readonly IDataGoKrHandlerProvider _handlerProvider;
    private readonly JsonSerializerOptions _serializerOptions;

    public AirQalityService(IDataGoKrHandlerProvider handlerProvider)
    {
        _handlerProvider = handlerProvider;
        _serializerOptions = new JsonSerializerOptions
        {
            Converters = {
                new AirKoeraJsonConverter<AirQalityByProvince>(),
                new AirKoeraJsonConverter<AirQalityStatistics>()
            },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
    }

    public ValueTask<AirQalityByProvinceResponse> GetAirQalityByProvinceAsync(AirQalityByProvinceProperties properties)
    {
        return GetAirQalityByProvinceAsync(properties, CancellationToken.None);
    }

    public async ValueTask<AirQalityByProvinceResponse> GetAirQalityByProvinceAsync(AirQalityByProvinceProperties properties, CancellationToken token)
    {
        var handle = await _handlerProvider.GetHandlerAsync();
        ArgumentNullException.ThrowIfNull(handle, nameof(handle));

        var result = await handle.GetAsync(
            AirQalityServiceEndpoint.AirQalityByProvinceEndpoint,
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

        return (await result.Content.ReadFromJsonAsync<AirQalityByProvinceResponse>(_serializerOptions, cancellationToken: token))!;
    }


    public ValueTask<AirQalityStatisticsResponse> GetAirQalityStatisticsByStateAsync(AirQalityStatisticsByStateProperty properties)
    {
        return GetAirQalityStatisticsByStateAsync(properties, CancellationToken.None);
    }

    public async ValueTask<AirQalityStatisticsResponse> GetAirQalityStatisticsByStateAsync(AirQalityStatisticsByStateProperty properties, CancellationToken token)
    {
        var handle = await _handlerProvider.GetHandlerAsync();
        ArgumentNullException.ThrowIfNull(handle, nameof(handle));

        var result = await handle.GetAsync(
            AirQalityServiceEndpoint.AirQalityAverageByState,
            new Dictionary<string, string?>()
            {
                {nameof(handle.Options.ServiceKey), handle.Options.ServiceKey },
                {nameof(properties.PageNo), properties.PageNo?.ToString() },
                {nameof(properties.ReturnType), properties.ReturnType?.ToString() },
                {nameof(properties.NumOfRows), properties.NumOfRows?.ToString() },
                {nameof(properties.SidoName), properties.SidoName.ToString() },
                {nameof(properties.SearchCondition), properties.SearchCondition.ToString() },
            },
            token);

        try
        {
            result.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        var data = await result.Content.ReadAsStringAsync(token);
        if (data[0] != '{')
        {
            throw new Exception(data);
        }

        return JsonSerializer.Deserialize<AirQalityStatisticsResponse>(data, _serializerOptions)!;
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(AirQalityByProvinceResponse))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}