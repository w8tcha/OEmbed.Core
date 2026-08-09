namespace OEmbed.Core.Providers;

public record TedProvider : Provider
{
    public TedProvider()
    {
        this.Name = "TED";
        this.Hosts = ["ted.com", "www.ted.com"];

        this.AddMatches(@"/talks/([\w-]+)/?(?:\?\S*)?");

        this.Endpoint = "https://www.ted.com/services/v1/oembed.json";
    }
}
