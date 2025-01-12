namespace OEmbed.Core.Providers;

/// <summary>
/// Class CloudflareStreamProvider.
/// </summary>
public record CloudflareStreamProvider : Provider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CloudflareStreamProvider"/> class.
    /// </summary>
    public CloudflareStreamProvider()
    {
        this.Name = "CloudflareStream";
        this.Hosts = ["cloudflarestream.com"];

        this.AddMatches(
            @"https:\/\/customer-(?<customerId>(.+?))\.cloudflarestream\.com\/(?<videoId>(.+?))\/");

        this.Html = """
                    <iframe src="{url}"></iframe>
                    """;
    }

    /// <summary>
    /// Gets the embed HTML for the Provider
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <param name="match">The match.</param>
    /// <param name="url">The URL.</param>
    /// <param name="hostUrl">The host URL.</param>
    /// <returns>OEmbed.Core.Response.</returns>
    public override Response GetHtml(Provider provider, Match match, string url, string hostUrl = null)
    {
        return new Response
        {
            Html = $"""
                    <iframe src="https://customer-{match.Groups["customerId"].Value}.cloudflarestream.com/{match.Groups["videoId"].Value}/iframe" 
                    height="400" width="400"
                    allow="accelerometer; gyroscope; autoplay; encrypted-media; picture-in-picture;" allowfullscreen></iframe>
                    """,
            Type = ResponseType.Video
        };
    }
}