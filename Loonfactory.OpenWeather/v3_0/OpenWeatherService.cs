using System.Text.Encodings.Web;
using System.Text.Json;

namespace Loonfactory.OpenWeather.v3_0;

public class OpenWeatherService
{
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly IOpenWeatherHandlerProvider _handlerProvider;

    public OpenWeatherService(IOpenWeatherHandlerProvider handlerProvider)
    {
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        _handlerProvider = handlerProvider;
    }


    public ValueTask<OneCallResponse> GetOneCallAsync(OneCallProperties properties)
    {
        return GetOneCallAsync(properties, CancellationToken.None);
    }

    public async ValueTask<OneCallResponse> GetOneCallAsync(OneCallProperties properties, CancellationToken token)
    {
        var handle = await _handlerProvider.GetHandlerAsync();
        ArgumentNullException.ThrowIfNull(handle, nameof(handle));

        var result = await handle.GetAsync(
            OpenWeatherDefaults.OneCallEndpoint,
            new Dictionary<string, string?>()
            {
                {"appid", handle.Options.ApiKey },
                {nameof(properties.Lat), properties.Lat.ToString() },
                {nameof(properties.Lon), properties.Lon.ToString() },
                {nameof(properties.Exclude), properties.Exclude },
                {nameof(properties.Units), properties.Units },
                {nameof(properties.Lang), properties.Lang },
            },
            token);

        result.EnsureSuccessStatusCode();

        return (await result.Content.ReadFromJsonAsync<OneCallResponse>(_serializerOptions, cancellationToken: token))!;
    }

}
