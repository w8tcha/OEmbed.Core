namespace OEmbed.Core.Providers;

public record InstagramProvider : Provider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InstagramProvider"/> class.
    /// </summary>
    public InstagramProvider()
    {
        this.Name = "Instagram";
        this.Hosts = new List<string> { "instagram.com", "www.instagram.com", "instagr.am", "www.instagr.am" };

        this.AddMatches(@"/(?:[\w_\-]+/)?(?:p/|tv/|reel/)?([a-zA-Z0-9_-]+)/?(?:[\w?#&=]+)?");

        this.Html = """
                    <iframe src="{url}/embed/captioned/"></iframe>
                    """;
    }
}