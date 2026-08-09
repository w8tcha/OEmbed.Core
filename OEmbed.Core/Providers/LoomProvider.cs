namespace OEmbed.Core.Providers;

public record LoomProvider : Provider
{
    public LoomProvider()
    {
        this.Name = "Loom";
        this.Hosts = ["loom.com", "www.loom.com"];

        this.AddMatches(@"/share/([a-zA-Z0-9]+)/?(?:\?\S*)?");

        this.Endpoint = "https://www.loom.com/v1/oembed";
    }
}
