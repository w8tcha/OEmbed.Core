namespace OEmbed.Core.Providers;

public record BlueskyProvider : Provider
{
    public BlueskyProvider()
    {
        this.Name = "Bluesky";
        this.Hosts = ["bsky.app"];

        this.AddMatches(@"/profile/([\w.\-:%]+)/post/([a-zA-Z0-9]+)/?(?:\?\S*)?");

        this.Endpoint = "https://embed.bsky.app/oembed";
    }
}
