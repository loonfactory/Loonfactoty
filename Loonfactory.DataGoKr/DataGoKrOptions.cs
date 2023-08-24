using System.Globalization;

namespace Loonfactory.DataGoKr;

public class DataGoKrOptions
{
    public string? ServiceKey { get; set; }

    public HttpMessageHandler? BackchannelHttpHandler { get; set; }

    public HttpClient Backchannel { get; set; } = default!;

    public TimeSpan BackchannelTimeout { get; set; } = TimeSpan.FromSeconds(60);

    public virtual void Validate()
    {
        if (string.IsNullOrEmpty(ServiceKey))
        {
            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Exception_OptionMustBeProvided, nameof(ServiceKey)), nameof(ServiceKey));
        }
    }
}
