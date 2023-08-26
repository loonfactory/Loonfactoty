namespace Loonfactory.DataGoKr
{
    public interface IDataGoKrHandlerProvider
    {
        Task<DataGoKrHandler?> GetHandlerAsync();
    }
}
