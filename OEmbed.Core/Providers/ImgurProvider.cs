namespace OEmbed.Core.Providers;

public record ImgurProvider : Provider
{
    public ImgurProvider()
    {
        this.Name = "Imgur";
        this.Hosts = ["imgur.com", "www.imgur.com", "m.imgur.com"];

        this.AddMatches(@"/(?:gallery/|a/|t/(?:[\w-]+)/)?([a-zA-Z0-9]+)/?(?:\?\S*)?");

        this.Endpoint = "https://api.imgur.com/oembed";
    }
}
