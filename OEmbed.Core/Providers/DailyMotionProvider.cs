namespace OEmbed.Core.Providers;

public record DailyMotionProvider : Provider
{
    public DailyMotionProvider()
    {
        this.Name = "DailyMotion";
        this.Hosts = new List<string>
                         {
                             "dailymotion.com", "www.dailymotion.com", "dai.ly"
                         };

        this.AddMatches(@"/(?:(?:embed/)?video/)?([\w]+)(?:[\w\?=]+)?");

        this.Endpoint = "https://www.dailymotion.com/services/oembed";
    }
}