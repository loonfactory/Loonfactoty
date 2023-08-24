using Microsoft.Extensions.Options;

namespace Loonfactory.DataGoKr;

public class DataGoKrPostConfigureOptions<TOptions> : IPostConfigureOptions<TOptions>
    where TOptions : DataGoKrOptions, new()
{
    public void PostConfigure(string? name, TOptions options)
    {
        if (options.Backchannel == null)
        {
            options.Backchannel = new HttpClient(options.BackchannelHttpHandler ?? new HttpClientHandler());
            options.Backchannel.DefaultRequestHeaders.UserAgent.ParseAdd("Loonfactory datagokr handler");
            options.Backchannel.Timeout = options.BackchannelTimeout;
            options.Backchannel.MaxResponseContentBufferSize = 10 * 1024 * 1024; // 10 MB
        }
    }
}
