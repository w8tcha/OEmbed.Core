using Newtonsoft.Json;

namespace OEmbed.Core;

/// <summary>
/// Class Response.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    [JsonProperty("type")] public string Type { get; set; }

    /// <summary>
    /// Gets or sets the version.
    /// </summary>
    /// <value>The version.</value>
    [JsonProperty("version")] public string Version { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    [JsonProperty("title")] public string Title { get; set; }

    /// <summary>
    /// Gets or sets the name of the author.
    /// </summary>
    /// <value>The name of the author.</value>
    [JsonProperty("author_name")] public string AuthorName { get; set; }

    /// <summary>
    /// Gets or sets the author URL.
    /// </summary>
    /// <value>The author URL.</value>
    [JsonProperty("author_url")] public string AuthorUrl { get; set; }

    /// <summary>
    /// Gets or sets the name of the provider.
    /// </summary>
    /// <value>The name of the provider.</value>
    [JsonProperty("provider_name")] public string ProviderName { get; set; }

    /// <summary>
    /// Gets or sets the provider URL.
    /// </summary>
    /// <value>The provider URL.</value>
    [JsonProperty("provider_url")] public string ProviderUrl { get; set; }

    /// <summary>
    /// Gets or sets the cache age.
    /// </summary>
    /// <value>The cache age.</value>
    [JsonProperty("cache_age")] public string CacheAge { get; set; }

    /// <summary>
    /// Gets or sets the thumbnail URL.
    /// </summary>
    /// <value>The thumbnail URL.</value>
    [JsonProperty("thumbnail_url")] public string ThumbnailUrl { get; set; }

    /// <summary>
    /// Gets or sets the width of the thumbnail.
    /// </summary>
    /// <value>The width of the thumbnail.</value>
    [JsonProperty("thumbnail_width")] public int ThumbnailWidth { get; set; }

    /// <summary>
    /// Gets or sets the height of the thumbnail.
    /// </summary>
    /// <value>The height of the thumbnail.</value>
    [JsonProperty("thumbnail_height")] public int ThumbnailHeight { get; set; }

    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    /// <value>The URL.</value>
    [JsonProperty("url")] public string Url { get; set; }

    /// <summary>
    /// Gets or sets the HTML.
    /// </summary>
    /// <value>The HTML.</value>
    [JsonProperty("html")] public string Html { get; set; }

    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    /// <value>The width.</value>
    [JsonProperty("width")] public string Width { get; set; }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    /// <value>The height.</value>
    [JsonProperty("height")] public string Height { get; set; }

    /// <summary>
    /// The photo template
    /// </summary>
    private const string PhotoTemplate = "<img src=\"{0}\" alt=\"{1}\" />";

    /// <summary>
    /// The link template
    /// </summary>
    private const string LinkTemplate = "<a href=\"{0}\">{1}</a>";

    /// <summary>
    /// Renders this instance.
    /// </summary>
    /// <returns>System.String.</returns>
    public string Render()
    {
        return this.Type switch
        {
            ResponseType.Video => this.Html,
            ResponseType.Photo => string.Format(PhotoTemplate, Encode(SafeUrl(this.Url)), Encode(this.Title)),
            ResponseType.Link => string.Format(LinkTemplate, Encode(SafeUrl(this.AuthorUrl)), Encode(this.Title ?? this.AuthorName)),
            ResponseType.Rich => this.Html,
            _ when !string.IsNullOrEmpty(this.Html) => this.Html,
            _ => throw new InvalidOperationException($"Unable to render oEmbed response: unknown type '{this.Type}' and no Html to fall back to.")
        };
    }

    /// <summary>
    /// HTML-encodes a value from the (untrusted) oEmbed response before it is placed into markup.
    /// </summary>
    /// <param name="value">The value.</param>
    private static string Encode(string value) => System.Net.WebUtility.HtmlEncode(value ?? string.Empty);

    /// <summary>
    /// Returns the URL only when it is an absolute http(s) URL, so that e.g. <c>javascript:</c> URLs
    /// from the oEmbed response can never end up in an <c>href</c> or <c>src</c> attribute.
    /// </summary>
    /// <param name="url">The URL.</param>
    private static string SafeUrl(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
        (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
            ? url
            : string.Empty;
}