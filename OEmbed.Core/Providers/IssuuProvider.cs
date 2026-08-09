namespace OEmbed.Core.Providers;

public record IssuuProvider : Provider
{
    public IssuuProvider()
    {
        this.Name = "Issuu";
        this.Hosts = ["issuu.com"];

        this.AddMatches(@"/(?:[\w-]+)/docs/([\w-]+)/?(?:\?\S*)?");

        this.Endpoint = "https://issuu.com/oembed";
    }
}
