using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Loonfactory.DataGoKr;

public class DataGoKrHandler<TOptions> where TOptions : DataGoKrOptions, new()
{
    public TOptions Options { get; private set; } = default!;

    protected IOptionsSnapshot<TOptions> OptionsSnapshot { get; }

    public ILogger Logger { get; }

    protected HttpClient Backchannel => Options.Backchannel;

    protected UrlEncoder UrlEncoder { get; }

    protected ISystemClock Clock { get; }

    protected DataGoKrHandler(
        IOptionsSnapshot<TOptions> optionsSnapshot,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
    )
    {
        OptionsSnapshot = optionsSnapshot;
        Logger = logger.CreateLogger(GetType().FullName!);
        UrlEncoder = encoder;
        Clock = clock;
    }

    public Task InitializeAsync()
    {
        Options = OptionsSnapshot.Value;

        return Task.CompletedTask;
    }

    protected string BuildUrl(string requestUrl, Dictionary<string, string?>? search)
    {
        if (search == null)
        {
            return requestUrl;
        }

        var searchPair = search
            .Where(pair => pair.Value != null)
            .Select(pair => $"{JsonNamingPolicy.CamelCase.ConvertName(pair.Key)}={UrlEncoder.Encode(pair.Value!)}");

        return $"{requestUrl}?{string.Join(",", searchPair)}";
    }


    public Task<HttpResponseMessage> GetAsync(
        [StringSyntax(StringSyntaxAttribute.Uri)] string? requestUri)
    {
        ArgumentNullException.ThrowIfNull(requestUri, nameof(requestUri));

        return GetAsync(requestUri, null);
    }

    public Task<HttpResponseMessage> GetAsync(
        [StringSyntax(StringSyntaxAttribute.Uri)] string? requestUri, 
        Dictionary<string, string?>? search)
    {
        ArgumentNullException.ThrowIfNull(requestUri, nameof(requestUri));

        return GetAsync(requestUri, search, CancellationToken.None);
    }



    public Task<HttpResponseMessage> GetAsync(
        [StringSyntax(StringSyntaxAttribute.Uri)] string? requestUri,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(requestUri, nameof(requestUri));

        return GetAsync(requestUri, null, cancellationToken);
    }

    public Task<HttpResponseMessage> GetAsync(
        [StringSyntax(StringSyntaxAttribute.Uri)] string? requestUri,
        Dictionary<string, string?>? search,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(requestUri, nameof(requestUri));

        return Backchannel.GetAsync(BuildUrl(requestUri, search), cancellationToken);
    }
}
