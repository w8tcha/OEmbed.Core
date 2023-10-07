using Newtonsoft.Json;

namespace OEmbed.Core;

public class Response
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("author_name")]
    public string AuthorName { get; set; }

    [JsonProperty("author_url")]
    public string AuthorUrl { get; set; }

    [JsonProperty("provider_name")]
    public string ProviderName { get; set; }

    [JsonProperty("provider_url")]
    public string ProviderUrl { get; set; }

    [JsonProperty("cache_age")]
    public string CacheAge { get; set; }

    [JsonProperty("thumbnail_url")]
    public string ThumbnailUrl { get; set; }

    [JsonProperty("thumbnail_width")]
    public int ThumbnailWidth { get; set; }

    [JsonProperty("thumbnail_height")]
    public int ThumbnailHeight { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("html")]
    public string Html { get; set; }

    [JsonProperty("width")]
    public string Width { get; set; }

    [JsonProperty("height")]
    public string Height { get; set; }

    private const string PhotoTemplate = "<img src=\"{0}\" alt=\"{1}\" />";

    private const string LinkTemplate = "<a href=\"{0}\">{1}</a>";
    public string Render()
    {
        return this.Type switch
            {
                ResponseType.Video => this.Html,
                ResponseType.Photo => string.Format(PhotoTemplate, this.Url, this.Title),
                ResponseType.Link => string.Format(LinkTemplate, this.AuthorUrl, this.Title ?? this.AuthorName),
                ResponseType.Rich => this.Html,
                _ => throw new InvalidOperationException()
            };
    }
}