namespace Loonfactory.DataGoKr;

public class DataGoKrHandlerProvider : IDataGoKrHandlerProvider
{
    private DataGoKrHandler? _handler = null;

    private IServiceProvider _serviceProvider;

    public DataGoKrHandlerProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Returns the handler instance that will be used.
    /// </summary>
    /// <returns>The handler instance.</returns>
    public async Task<DataGoKrHandler?> GetHandlerAsync()
    {
        if (_handler != null)
        {
            return _handler;
        }

        var handler = (_serviceProvider.GetService(typeof(DataGoKrHandler)) ??
            ActivatorUtilities.CreateInstance(_serviceProvider, typeof(DataGoKrHandler)))
            as DataGoKrHandler;

        if (handler != null)
        {
            await handler.InitializeAsync();
            _handler = handler;
        }

        return handler;
    }
}