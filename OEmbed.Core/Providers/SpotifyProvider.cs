namespace OEmbed.Core.Providers;

public record SpotifyProvider : Provider
{
    public SpotifyProvider()
    {
        this.Name = "Spotify";
        this.Hosts = ["open.spotify.com"];

        this.AddMatches(
            @"/(?:artist|track|album|playlist|show|episode)/([a-zA-Z0-9]+)/?(?:[^/^\s]*)?",
            @"/user/(?:[a-zA-Z0-9]+)/playlist/([a-zA-Z0-9]+)/?(?:[^/^\s]*)?");

        this.Endpoint = "https://open.spotify.com/oembed";
    }
}