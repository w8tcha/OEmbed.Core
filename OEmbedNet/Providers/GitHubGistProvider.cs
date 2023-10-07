namespace OEmbed.Net.Providers;

public record GitHubGistProvider : Provider
{
    public GitHubGistProvider()
    {
        this.Name = "GitHubGist";
        this.Hosts = new List<string> { "gist.github.com" };

        this.AddMatches("/(.+)/([a-zA-Z0-9]+)?");

        this.Html = """
                    <iframe src="{url}.pibb"></iframe>
                    """;
    }
}