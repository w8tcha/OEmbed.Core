namespace OEmbed.Core.Providers;

public record ScribdProvider : Provider
{
    public ScribdProvider()
    {
        this.Name = "Scribd";
        this.Hosts = ["scribd.com", "www.scribd.com"];

        this.AddMatches(@"/(?:document|doc)/(\d+)(?:/[\w-]+)?/?(?:\?\S*)?");

        this.Endpoint = "https://www.scribd.com/services/oembed";
    }
}
