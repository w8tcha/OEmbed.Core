namespace OEmbed.Core.Providers;

public record YouTubeProvider : Provider
{
    public YouTubeProvider()
    {
        this.Name = "YouTube";

        this.Hosts =
        [
            "m.youtube.com",
            "youtu.be",
            "youtube.com",
            "www.youtu.be",
            "www.youtube.com"
        ];

        this.AddMatches(@"/(?:embed/|video/|shorts/|live/|playlist\?list=|watch\?v=)?([\w|-]+)(?:[\w\&\?\=\.\-]+)?");

        this.Endpoint = "https://www.youtube.com/oembed";
    }
}