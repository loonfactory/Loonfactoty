namespace Loonfactory.OpenWeather.v3_0;

public interface IOpenWeatherService
{
    public ValueTask<OneCallResponse> GetOneCallAsync(OneCallProperties properties);
    public ValueTask<OneCallResponse> GetOneCallAsync(OneCallProperties properties, CancellationToken token);
}
