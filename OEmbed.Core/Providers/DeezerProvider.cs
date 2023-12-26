namespace OEmbed.Core.Providers;

public record DeezerProvider : Provider
{
    public DeezerProvider()
    {
        this.Name = "Deezer";

        this.Hosts = ["www.deezer.com", "deezer.com", "deezer.page.link"];

        this.AddMatches(@"/(?:\w+/)?(track|playlist|album)/(\d+)/?");

        this.Endpoint = "https://api.deezer.com/oembed";
    }
}