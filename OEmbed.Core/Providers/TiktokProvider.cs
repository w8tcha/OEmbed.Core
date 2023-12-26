namespace OEmbed.Core.Providers;

public record TikTokProvider : Provider
{
    public TikTokProvider()
    {
        this.Name = "TikTok";
        this.Hosts =
        [
            "tiktok.com",
            "www.tiktok.com",
            "m.tiktok.com"
        ];

        this.AddMatches("/(@[^/]*)", @"/(?:v|@[^\/]*\/video)\/(\d+)(?:\.html|(?:\?\S*)?)");

        this.Endpoint = "https://www.tiktok.com/oembed";
    }
}