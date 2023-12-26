namespace OEmbed.Core;

#if NET481
using System.IO;
#endif
using System.Linq;
using System.Net;
#if NET7_0_OR_GREATER
using System.Net.Http;
#endif
using System.Runtime.Caching;

using global::OEmbed.Core.Interfaces;

using Newtonsoft.Json;

public class OEmbed : IOEmbed
{
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

#if NET7_0_OR_GREATER
        this.httpClient = new HttpClient();
        this.httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(agent);
#endif
    }

#if NET481
    private readonly string _userAgent;
#endif

#if NET7_0_OR_GREATER
    private readonly HttpClient httpClient;
#endif

    private readonly Options _options;

    private static readonly MemoryCache Cache = MemoryCache.Default;

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
        return this.Providers.Any(p => p.CanHandleUrl(uri));
    }

#if NET481
    /// <summary>
    /// Embeds the specified URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>Response.</returns>
    public Response Embed(string url)
    {
        if (url == null)
        {
            return null;
        }

        var uri = new Uri(url);

        var provider = Providers.FirstOrDefault(p => p.CanHandleUrl(uri));

        if (provider == null)
        {
            return null;
        }

        var match = provider.MatchScheme(uri);

        if (!match)
        {
            return null;
        }

        if (Cache.Contains(url))
        {
            return (Response)Cache.Get(url);
        }

        return string.IsNullOrEmpty(provider.Endpoint) ? GetHtml(provider, url) : this.GetJson(provider, url);
    }
#endif

#if NET7_0_OR_GREATER
    /// <summary>
    /// Embeds the specified URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>Response.</returns>
    public async Task<Response> EmbedAsync(string url)
    {
        if (url == null)
        {
            return null;
        }

        var uri = new Uri(url);

        var provider = this.Providers.FirstOrDefault(p => p.CanHandleUrl(uri));

        if (provider == null)
        {
            return null;
        }

        var match = provider.MatchScheme(uri);

        if (!match)
        {
            return null;
        }

        if (Cache.Contains(url))
        {
            return (Response)Cache.Get(url);
        }

        return string.IsNullOrEmpty(provider.Endpoint)
                   ? GetHtml(provider, url)
                   : await this.GetJsonAsync(provider, url);
    }

#endif

    private static Response GetHtml(Provider provider, string url)
    {
        var response = new Response { Html = provider.Html.Replace("{url}", url), Type = ResponseType.Rich };

        return response;
    }

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

#if NET7_0_OR_GREATER
    /// <summary>
    /// Get the oEmbed JSON
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <param name="url">The URL.</param>
    /// <returns>Returns the JSON Response</returns>
    private async Task<Response> GetJsonAsync(Provider provider, string url)
    {
        var endpoint = $"{provider.Endpoint}?url={WebUtility.UrlEncode(url)}&format=json";

        var content = await this.httpClient.GetStringAsync(endpoint);

        var response = JsonConvert.DeserializeObject<Response>(content);

        if (this.options.EnableCache)
        {
            Cache.Add(url, response, DateTimeOffset.Now.AddDays(1));
        }

        return response;
    }
#endif
}