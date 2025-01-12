

namespace OEmbed.Core;

#if NET481
using System.IO;
#endif

using System.Net;

#if NET8_0_OR_GREATER
using System.Net.Http;
#endif
using System.Runtime.Caching;

using global::OEmbed.Core.Interfaces;

using Newtonsoft.Json;

/// <summary>
/// Class OEmbed.
/// Implements the <see cref="IOEmbed" />
/// </summary>
/// <seealso cref="IOEmbed" />
public class OEmbed : IOEmbed
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OEmbed"/> class.
    /// </summary>
    public OEmbed()
    {
        this.Providers = new ProviderList().GetProviders();

        this._options = new Options();

        var type = typeof(OEmbed);
        var assemblyName = type.Assembly.GetName();

        var agent = $"{type.Namespace}/{assemblyName!.Version!.Major}.{assemblyName!.Version!.Minor}";


#if NET481
        this._userAgent = agent;
#endif

#if NET8_0_OR_GREATER
        this._httpClient = new HttpClient();
        this._httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(agent);
#endif
    }

#if NET481
    private readonly string _userAgent;
#endif

#if NET8_0_OR_GREATER
    private readonly HttpClient _httpClient;
#endif

    private readonly Options _options;

    private static readonly MemoryCache Cache = MemoryCache.Default;

    /// <summary>
    /// Gets or sets the providers.
    /// </summary>
    /// <value>The providers.</value>
    public List<Provider> Providers { get; set; }

    /// <summary>
    /// Check if url matches any Provider Host address
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns><c>true</c> if this instance can embed the specified URL; otherwise, <c>false</c>.</returns>
    public bool CanEmbed(string url) => this.CanEmbed(new Uri(url));

    /// <summary>
    /// Check if url matches any Provider Host address
    /// </summary>
    /// <param name="uri">The URI.</param>
    /// <returns><c>true</c> if this instance can embed the specified URI; otherwise, <c>false</c>.</returns>
    public bool CanEmbed(Uri uri)
    {
        return this.Providers.Exists(p => p.CanHandleUrl(uri));
    }

#if NET481
    /// <summary>
    /// Embeds the specified URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <param name="hostUrl">The host URL.</param>
    /// <returns>Response.</returns>
    public Response Embed(string url, string hostUrl = null)
    {
        if (url == null)
        {
            return null;
        }

        var uri = new Uri(url);

        var provider = Providers.Find(p => p.CanHandleUrl(uri));

        var match = provider?.MatchScheme(uri);

        if (match is null || !match.Success)
        {
            return null;
        }

        if (Cache.Contains(url))
        {
            return (Response)Cache.Get(url);
        }

        return string.IsNullOrEmpty(provider.Endpoint) ? provider.GetHtml(provider, match, url, hostUrl) : this.GetJson(provider, url);
    }
#endif

#if NET8_0_OR_GREATER
    /// <summary>
    /// Embeds the specified URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <param name="hostUrl">The host URL.</param>
    /// <returns>Response.</returns>
    public async Task<Response> EmbedAsync(string url, string hostUrl = null)
    {
        if (url == null)
        {
            return null;
        }

        var uri = new Uri(url);

        var provider = this.Providers.Find(p => p.CanHandleUrl(uri));

        var match = provider?.MatchScheme(uri);

        if (match is null || !match.Success)
        {
            return null;
        }

        if (Cache.Contains(url))
        {
            return (Response)Cache.Get(url);
        }

        return string.IsNullOrEmpty(provider.Endpoint)
                   ? provider.GetHtml(provider, match, url, hostUrl)
                   : await this.GetJsonAsync(provider, url);
    }

#endif

#if NET481
    /// <summary>
    /// Get the oEmbed JSON
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <param name="url">The URL.</param>
    /// <returns>Returns the JSON Response</returns>
    private Response GetJson(Provider provider, string url)
    {
        var endpoint = $"{provider.Endpoint}?url={WebUtility.UrlEncode(url)}&format=json";

        var webRequest = (HttpWebRequest)WebRequest.Create(endpoint);

        webRequest.UserAgent = this._userAgent;

        try
        {
            var webResponse = (HttpWebResponse)webRequest.GetResponse();

            var responseStream = webResponse.GetResponseStream();

            if (responseStream == null)
            {
                return null;
            }

            var streamReader = new StreamReader(responseStream);

            var content = streamReader.ReadToEnd();

            var response = JsonConvert.DeserializeObject<Response>(content);

            if (this._options.EnableCache)
            {
                Cache.Add(url, response, DateTimeOffset.Now.AddDays(1));
            }

            return response;
        }
        catch (Exception)
        {
            return null;
        }
    }
#endif

#if NET8_0_OR_GREATER
    /// <summary>
    /// Get the oEmbed JSON
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <param name="url">The URL.</param>
    /// <returns>Returns the JSON Response</returns>
    private async Task<Response> GetJsonAsync(Provider provider, string url)
    {
        var endpoint = $"{provider.Endpoint}?url={WebUtility.UrlEncode(url)}&format=json";

        var content = await this._httpClient.GetStringAsync(endpoint);

        var response = JsonConvert.DeserializeObject<Response>(content);

        if (this._options.EnableCache)
        {
            Cache.Add(url, response, DateTimeOffset.Now.AddDays(1));
        }

        return response;
    }
#endif
}