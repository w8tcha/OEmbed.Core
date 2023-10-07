namespace OEmbed.Net.Providers;

public record TikTokProvider : Provider
{
    public TikTokProvider()
    {
        this.Name = "TikTok";
        this.Hosts = new List<string>
                         {
                             "tiktok.com",
                             "www.tiktok.com",
                             "m.tiktok.com"
                         };

        this.AddMatches("/(@[^/]*)", @"/(?:v|@[^\/]*\/video)\/(\d+)(?:\.html|(?:\?\S*)?)");

        this.Endpoint = "https://www.tiktok.com/oembed";
    }
}