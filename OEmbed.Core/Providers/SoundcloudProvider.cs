namespace OEmbed.Core.Providers;

public record SoundCloudProvider : Provider
{
    public SoundCloudProvider()
    {
        this.Name = "SoundCloud";
        this.Hosts = ["soundcloud.com"];

        this.AddMatches(@"/(?!discover|stream|upload|popular|charts|people|pages|imprint|you)([\S]+)");

        this.Endpoint = "https://soundcloud.com/oembed";
    }
}