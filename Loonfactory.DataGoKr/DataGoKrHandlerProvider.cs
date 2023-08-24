namespace Loonfactory.DataGoKr;

public class DataGoKrHandlerProvider<TOptions> : IDataGoKrHandlerProvider<TOptions> where TOptions : DataGoKrOptions, new()
{
    private DataGoKrHandler<TOptions>? _handler = null;

    private IServiceProvider _serviceProvider;

    public DataGoKrHandlerProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Returns the handler instance that will be used.
    /// </summary>
    /// <returns>The handler instance.</returns>
    public async Task<DataGoKrHandler<TOptions>?> GetHandlerAsync()
    {
        if (_handler != null)
        {
            return _handler;
        }

        var handler = (_serviceProvider.GetService(typeof(DataGoKrHandler<TOptions>)) ??
            ActivatorUtilities.CreateInstance(_serviceProvider, typeof(DataGoKrHandler<TOptions>)))
            as DataGoKrHandler<TOptions>;

        if (handler != null)
        {
            await handler.InitializeAsync();
            _handler = handler;
        }

        return handler;
    }
}