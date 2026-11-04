namespace OEmbed.Core.Tests.Helpers;

/// <summary>
/// A provider that only lives in the test assembly, so <see cref="ProviderList"/> never picks it up.
/// </summary>
public record TestProvider : Provider
{
    public TestProvider(string endpoint = null, params string[] patterns)
    {
        this.Name = "Test";
        this.Hosts = ["example.com"];
        this.Endpoint = endpoint;

        this.AddMatches(patterns.Length > 0 ? patterns : [@"/video/(?<id>[0-9]+)"]);

        this.Html = """
                    <iframe src="{url}"></iframe>
                    """;
    }
}
