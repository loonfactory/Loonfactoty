using System.Globalization;

namespace Loonfactory.OpenWeather.v3_0;

public class OpenWeatherOptions
{
    public string? ApiKey { get; set; }

    public HttpMessageHandler? BackchannelHttpHandler { get; set; }

    public HttpClient Backchannel { get; set; } = default!;

    public TimeSpan BackchannelTimeout { get; set; } = TimeSpan.FromSeconds(60);

    public virtual void Validate()
    {
        if (string.IsNullOrEmpty(ApiKey))
        {
            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Exception_OptionMustBeProvided, nameof(ServiceKey)), nameof(ServiceKey));
        }
    }
}
