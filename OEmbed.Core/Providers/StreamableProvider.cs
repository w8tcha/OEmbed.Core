namespace OEmbed.Core.Providers;

public record StreamableProvider : Provider
{
    public StreamableProvider()
    {
        this.Name = "Streamable";
        this.Hosts = ["streamable.com"];

        this.AddMatches(@"/(?!about|terms|privacy|faq|pricing|login|signup|api|blog)([a-zA-Z0-9]+)/?(?:\?\S*)?");

        this.Endpoint = "https://api.streamable.com/oembed.json";
    }
}
