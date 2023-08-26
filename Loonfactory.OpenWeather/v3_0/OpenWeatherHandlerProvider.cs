namespace Loonfactory.OpenWeather.v3_0;

public class OpenWeatherHandlerProvider : IOpenWeatherHandlerProvider
{
    private OpenWeatherHandler? _handler = null;

    private IServiceProvider _serviceProvider;

    public OpenWeatherHandlerProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Returns the handler instance that will be used.
    /// </summary>
    /// <returns>The handler instance.</returns>
    public async Task<OpenWeatherHandler?> GetHandlerAsync()
    {
        if (_handler != null)
        {
            return _handler;
        }

        var handler = (_serviceProvider.GetService(typeof(OpenWeatherHandler)) ??
            ActivatorUtilities.CreateInstance(_serviceProvider, typeof(OpenWeatherHandler)))
            as OpenWeatherHandler;

        if (handler != null)
        {
            await handler.InitializeAsync();
            _handler = handler;
        }

        return handler;
    }
}