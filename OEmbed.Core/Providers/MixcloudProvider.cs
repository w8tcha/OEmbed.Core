namespace OEmbed.Core.Providers;

public record MixcloudProvider : Provider
{
    public MixcloudProvider()
    {
        this.Name = "Mixcloud";
        this.Hosts = ["mixcloud.com", "www.mixcloud.com"];

        this.AddMatches(@"/(?:[\w-]+)/(?:[\w-]+)/?(?:\?\S*)?");

        this.Endpoint = "https://app.mixcloud.com/oembed/";
    }
}
