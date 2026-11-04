namespace OEmbed.Core.Tests;

/// <summary>
/// Tests for the default behaviour of the <see cref="Provider"/> base record.
/// </summary>
public class ProviderBaseTests
{
    [TestCase("https://example.com/video/1")]
    [TestCase("https://EXAMPLE.com/video/1")]
    [TestCase("https://www.example.com/video/1")]
    [TestCase("https://a.b.example.com/video/1")]
    public void CanHandleUrl_MatchesHostAndSubdomains(string url)
    {
        new TestProvider().CanHandleUrl(new Uri(url)).Should().BeTrue();
    }

    [TestCase("https://notexample.com/video/1")]
    [TestCase("https://example.com.evil.org/video/1")]
    [TestCase("https://example.org/video/1")]
    public void CanHandleUrl_RejectsLookalikeHosts(string url)
    {
        new TestProvider().CanHandleUrl(new Uri(url)).Should().BeFalse();
    }

    [Test]
    public void MatchScheme_MatchesPathAndQuery()
    {
        var match = new TestProvider().MatchScheme(new Uri("https://example.com/video/42"));

        match.Success.Should().BeTrue();
        match.Groups["id"].Value.Should().Be("42");
    }

    [Test]
    public void MatchScheme_IsAnchored()
    {
        var match = new TestProvider().MatchScheme(new Uri("https://example.com/video/42/extra"));

        match.Should().BeNull();
    }

    [Test]
    public void MatchScheme_FallsBackToAbsoluteUri()
    {
        var provider = new TestProvider(null, @"https://(?<sub>[a-z]+)\.example\.com/.*");

        var match = provider.MatchScheme(new Uri("https://cdn.example.com/anything"));

        match.Success.Should().BeTrue();
        match.Groups["sub"].Value.Should().Be("cdn");
    }

    [Test]
    public void MatchScheme_ReturnsNullOnRegexTimeout()
    {
        // Catastrophic backtracking pattern - must hit the 500ms match timeout instead of hanging.
        var provider = new TestProvider(null, "/(x+x+)+y");

        var match = provider.MatchScheme(new Uri("https://example.com/" + new string('x', 64)));

        match.Should().BeNull();
    }

    [Test]
    public void GetHtml_ReplacesUrlPlaceholderAndReturnsRich()
    {
        var provider = new TestProvider();
        const string Url = "https://example.com/video/1";

        var response = provider.GetHtml(provider, provider.MatchScheme(new Uri(Url)), Url);

        response.Type.Should().Be(ResponseType.Rich);
        response.Html.Should().Contain("""src="https://example.com/video/1" """.TrimEnd());
    }

    [Test]
    public void GetHtml_HtmlEncodesUrl()
    {
        var provider = new TestProvider();
        const string Url = "https://example.com/video/1?a=\"><script>alert(1)</script>";

        var response = provider.GetHtml(provider, null, Url);

        response.Html.Should().Be(
            """<iframe src="https://example.com/video/1?a=&quot;&gt;&lt;script&gt;alert(1)&lt;/script&gt;"></iframe>""");
    }
}
