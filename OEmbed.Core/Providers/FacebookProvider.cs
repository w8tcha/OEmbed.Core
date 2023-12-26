namespace OEmbed.Core.Providers;

public record FacebookProvider : Provider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookProvider"/> class.
    /// </summary>
    public FacebookProvider()
    {
        this.Name = "Facebook";
        this.Hosts = ["facebook.com", "www.facebook.com"];

        this.AddMatches(
            "/(?:[^/]+)/(?:posts|activity|photos)/([^/]+)/?",
            "/notes/(?:[^/]+)/(?:[^/]+)/(?:[^/]+)/?",
            @"/(?:photo|permalink)(?:\.php|/)\?(?:(?:story_)?fbid)=([0-9]+)\S*",
            @"/(?:photos/|questions/|media/set\?set=)(?:[^/]+)/?",
            @"/(?:[^/]+)/videos/([\d]+)/?",
            @"/video\.php\?(?:id|v)=([\d]+)/?");

        this.Html = """
                    <iframe src="https://www.facebook.com/plugins/post.php?href={url}" />
                    """;
    }
}