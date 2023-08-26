namespace Loonfactory.OpenWeather.v3_0;

public interface IOpenWeatherHandlerProvider
{
    Task<OpenWeatherHandler?> GetHandlerAsync();
}
