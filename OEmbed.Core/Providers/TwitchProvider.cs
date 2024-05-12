namespace OEmbed.Core.Providers;

/// <summary>
/// Class TwitchProvider.
/// </summary>
public record TwitchProvider : Provider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TwitchProvider"/> class.
    /// </summary>
    public TwitchProvider()
    {
        this.Name = "Twitch";
        this.Hosts = ["twitch.tv", "www.twitch.tv", "go.twitch.tv"];

        this.AddMatches(
            "/(?!videos|clip)(?<channel>([a-zA-Z0-9]+))?",
            "/(?:videos)/(?<videoId>[0-9]+)?",
             @"/(?:[\w_\-]+/)?(?:clip)/(?<clipId>(.*?))?");

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
    /// <returns>OEmbed.Core.Response.</returns>
    public override Response GetHtml(Provider provider, Match match, string url)
    {
        if (!string.IsNullOrEmpty(match.Groups["videoId"].Value))
        {
            return new Response { Html = $"""
                                          <iframe src="https://player.twitch.tv/?video={match.Groups["videoId"].Value}&parent=twitch.tv&autoplay=false" height="720" width="1280" allowfullscreen></iframe>
                                          """, Type = ResponseType.Rich };
        }

        if (!string.IsNullOrEmpty(match.Groups["clipId"].Value))
        {
            return new Response { Html = $"""
                                          <iframe src="https://player.twitch.tv/?collection={match.Groups["clipId"].Value}&parent=twitch.tv" height="720" width="1280" allowfullscreen></iframe>
                                          """, Type = ResponseType.Rich };
        }

        if (!string.IsNullOrEmpty(match.Groups["channel"].Value))
        {
            return new Response { Html = $"""
                                          <iframe src="https://player.twitch.tv/?channel={match.Groups["channel"].Value}&parent=twitch.tv&muted=true" height="720" width="1280" allowfullscreen></iframe>
                                          """, Type = ResponseType.Rich };
        }

        return new Response { Html = provider.Html.Replace("{url}", url), Type = ResponseType.Rich };
    }
}