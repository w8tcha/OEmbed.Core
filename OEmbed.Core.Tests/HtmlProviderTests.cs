namespace OEmbed.Core.Tests;

/// <summary>
/// Offline tests for providers that build their embed HTML themselves instead of calling an oEmbed endpoint.
/// </summary>
public class HtmlProviderTests
{
    private static Response GetHtml(Provider provider, string url, string hostUrl = null) =>
        provider.GetHtml(provider, provider.MatchScheme(new Uri(url)), url, hostUrl);

    [Test]
    public void Twitch_WithoutHostUrl_ReturnsNull()
    {
        GetHtml(new TwitchProvider(), "https://www.twitch.tv/therealknossi").Should().BeNull();
    }

    [Test]
    public void Twitch_Channel()
    {
        var response = GetHtml(new TwitchProvider(), "https://www.twitch.tv/therealknossi", "localhost");

        response.Type.Should().Be(ResponseType.Rich);
        response.Html.Should().Contain("https://player.twitch.tv/?channel=therealknossi&parent=localhost&muted=true");
    }

    [Test]
    public void Twitch_Video()
    {
        var response = GetHtml(new TwitchProvider(), "https://www.twitch.tv/videos/2141265767", "localhost");

        response.Type.Should().Be(ResponseType.Rich);
        response.Html.Should().Contain("https://player.twitch.tv/?video=2141265767&parent=localhost&autoplay=false");
    }

    [Test]
    public void Twitch_Clip()
    {
        var response = GetHtml(
            new TwitchProvider(),
            "https://www.twitch.tv/therealknossi/clip/DiligentRelatedBisonVoteYea-5mkamtYyocJOfu79",
            "localhost");

        response.Type.Should().Be(ResponseType.Rich);
        response.Html.Should().Contain(
            "https://clips.twitch.tv/embed?clip=DiligentRelatedBisonVoteYea-5mkamtYyocJOfu79&parent=localhost");
    }

    [Test]
    public void Twitch_RootUrl_FallsBackToTemplate()
    {
        var response = GetHtml(new TwitchProvider(), "https://www.twitch.tv/", "localhost");

        response.Type.Should().Be(ResponseType.Rich);
        response.Html.Should().Contain("""<iframe src="https://www.twitch.tv/">""");
    }

    [Test]
    public void Twitch_HtmlEncodesHostUrl()
    {
        var response = GetHtml(new TwitchProvider(), "https://www.twitch.tv/therealknossi", "x\"><script>");

        response.Html.Should().NotContain("<script>");
        response.Html.Should().Contain("parent=x&quot;&gt;&lt;script&gt;");
    }

    [Test]
    public void CloudflareStream_BuildsIframeFromCustomerAndVideoId()
    {
        var response = GetHtml(
            new CloudflareStreamProvider(),
            "https://customer-aw5py76sw8wyqzmh.cloudflarestream.com/2463f6d3e06fa29710a337f5f5389fd8/");

        response.Type.Should().Be(ResponseType.Video);
        response.Html.Should().Contain(
            "https://customer-aw5py76sw8wyqzmh.cloudflarestream.com/2463f6d3e06fa29710a337f5f5389fd8/iframe");
    }

    [TestCase("https://gist.github.com/user/abc123", """<iframe src="https://gist.github.com/user/abc123.pibb"></iframe>""")]
    [TestCase("https://www.instagram.com/p/CbFHMRqv2Fa/", """<iframe src="https://www.instagram.com/p/CbFHMRqv2Fa//embed/captioned/"></iframe>""")]
    [TestCase("https://www.facebook.com/zuck/posts/10102577175875681", """<iframe src="https://www.facebook.com/plugins/post.php?href=https://www.facebook.com/zuck/posts/10102577175875681" />""")]
    public void TemplateProviders_RenderUrlIntoTemplate(string url, string expectedHtml)
    {
        var embed = new OEmbed();
        var uri = new Uri(url);
        var provider = embed.Providers.Find(p => p.CanHandleUrl(uri));

        var response = GetHtml(provider, url);

        response.Type.Should().Be(ResponseType.Rich);
        response.Html.Should().Be(expectedHtml);
    }
}
