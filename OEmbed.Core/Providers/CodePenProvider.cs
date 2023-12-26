namespace OEmbed.Core.Providers;

public record CodePenProvider : Provider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodePenProvider"/> class.
    /// </summary>
    public CodePenProvider()
    {
        this.Name = "CodePen";
        this.Hosts = ["codepen.io"];

        this.AddMatches(@"/(?:team/)?(?:[\w]+)/pen/([\w]+)/?");

        this.Endpoint = "https://codepen.io/api/oembed";
    }
}