namespace Loonfactory.DataGoKr
{
    public interface IDataGoKrHandlerProvider<TOptions> where TOptions : DataGoKrOptions, new()
    {
        Task<DataGoKrHandler<TOptions>?> GetHandlerAsync();
    }
}
