using Microsoft.Extensions.Options;

namespace Loonfactory.OpenWeather.v3_0;

public class OpenWeatherPostConfigureOptions<TOptions> : IPostConfigureOptions<TOptions>
    where TOptions : OpenWeatherOptions, new()
{
    public void PostConfigure(string? name, TOptions options)
    {
        if (options.Backchannel == null)
        {
            options.Backchannel = new HttpClient(options.BackchannelHttpHandler ?? new HttpClientHandler());
            options.Backchannel.DefaultRequestHeaders.UserAgent.ParseAdd("Loonfactory OpenWeather handler");
            options.Backchannel.Timeout = options.BackchannelTimeout;
            options.Backchannel.MaxResponseContentBufferSize = 10 * 1024 * 1024; // 10 MB
        }
    }
}
