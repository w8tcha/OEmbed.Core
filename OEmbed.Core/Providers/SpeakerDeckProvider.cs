namespace OEmbed.Core.Providers;

public record SpeakerDeckProvider : Provider
{
    public SpeakerDeckProvider()
    {
        this.Name = "SpeakerDeck";
        this.Hosts = ["speakerdeck.com"];

        this.AddMatches(@"/(?:[\w-]+)/([a-zA-Z0-9-]+)/?(?:\?\S*)?");

        this.Endpoint = "https://speakerdeck.com/oembed.json";
    }
}
