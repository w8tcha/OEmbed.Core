namespace OEmbed.Core.Tests;

#if NET9_0_OR_GREATER
using System.Net;
using System.Net.Http;
#endif

/// <summary>
/// Offline tests for <see cref="OEmbed"/> itself. None of these hit the network.
/// </summary>
public class OEmbedTests
{
    private const string SpotifyJson = """
                                       {"type":"rich","version":"1.0","title":"Song","provider_name":"Spotify","html":"<iframe></iframe>"}
                                       """;

    /// <summary>
    /// The response cache is process wide (<c>MemoryCache.Default</c>), so every test that might populate it uses its own URL.
    /// </summary>
    private static string UniqueSpotifyUrl() => $"https://open.spotify.com/track/4uLU6hMCjMI75M1A2tKUQC?si={Guid.NewGuid():N}";

    [Test]
    public void Constructor_LoadsAllProviders()
    {
        new OEmbed().Providers.Should().HaveCount(ProviderList.GetProviders().Count);
    }

    [Test]
    public void Constructor_AcceptsNullOptions()
    {
        var act = () => new OEmbed(null);

        act.Should().NotThrow();
    }

    [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc")]
    [TestCase("https://vimeo.com/22439234")]
    public void CanEmbed_KnownHost_ReturnsTrue(string url)
    {
        var embed = new OEmbed();

        embed.CanEmbed(url).Should().BeTrue();
        embed.CanEmbed(new Uri(url)).Should().BeTrue();
    }

    [TestCase("https://example.org/video/1")]
    [TestCase("https://notyoutube.com/watch?v=LKWFkELeYwc")]
    public void CanEmbed_UnknownHost_ReturnsFalse(string url)
    {
        new OEmbed().CanEmbed(url).Should().BeFalse();
    }

    [Test]
    public void CanEmbed_RelativeString_Throws()
    {
        var act = () => new OEmbed().CanEmbed("testing");

        act.Should().Throw<UriFormatException>();
    }

    [Test]
    public void Providers_CanBeReplaced()
    {
        var embed = new OEmbed { Providers = [new TestProvider()] };

        embed.CanEmbed("https://example.com/video/1").Should().BeTrue();
        embed.CanEmbed("https://www.youtube.com/watch?v=LKWFkELeYwc").Should().BeFalse();
    }

#if NET481
    [TestCase("testing")]
    [TestCase("")]
    [TestCase(null)]
    public void Embed_InvalidUrl_ReturnsNull(string url)
    {
        new OEmbed().Embed(url).Should().BeNull();
    }

    [Test]
    public void Embed_UnknownHost_ReturnsNull()
    {
        new OEmbed().Embed("https://example.org/video/1").Should().BeNull();
    }

    [Test]
    public void Embed_KnownHostButUnmatchedPath_ReturnsNull()
    {
        new OEmbed { Providers = [new TestProvider()] }.Embed("https://example.com/nope").Should().BeNull();
    }

    [Test]
    public void Embed_HtmlProvider_ReturnsRenderedTemplate()
    {
        var actual = new OEmbed { Providers = [new TestProvider()] }.Embed("https://example.com/video/1");

        actual.Type.Should().Be(ResponseType.Rich);
        actual.Html.Should().Contain("""src="https://example.com/video/1" """.TrimEnd());
    }

    [Test]
    public void Embed_PassesHostUrlToProvider()
    {
        var embed = new OEmbed();

        embed.Embed("https://www.twitch.tv/therealknossi").Should().BeNull();
        embed.Embed("https://www.twitch.tv/therealknossi", "localhost").Html.Should().Contain("parent=localhost");
    }

    [Test]
    public void Embed_UnreachableEndpoint_ReturnsNull()
    {
        var embed = new OEmbed { Providers = [new TestProvider("http://localhost:1/oembed")] };

        embed.Embed("https://example.com/video/1").Should().BeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [TestCase("testing")]
    [TestCase("")]
    [TestCase(null)]
    public async Task EmbedAsync_InvalidUrl_ReturnsNull(string url)
    {
        (await new OEmbed().EmbedAsync(url)).Should().BeNull();
    }

    [Test]
    public async Task EmbedAsync_UnknownHost_ReturnsNull()
    {
        var handler = FakeHttpMessageHandler.Json(SpotifyJson);

        (await new OEmbed(new Options(), handler).EmbedAsync("https://example.org/video/1")).Should().BeNull();

        handler.Requests.Should().BeEmpty();
    }

    [Test]
    public async Task EmbedAsync_KnownHostButUnmatchedPath_ReturnsNull()
    {
        var handler = FakeHttpMessageHandler.Json(SpotifyJson);

        (await new OEmbed(new Options(), handler).EmbedAsync("https://open.spotify.com/not-a-track")).Should().BeNull();

        handler.Requests.Should().BeEmpty();
    }

    [Test]
    public async Task EmbedAsync_HtmlProvider_DoesNotCallEndpoint()
    {
        var handler = FakeHttpMessageHandler.Json(SpotifyJson);
        var embed = new OEmbed(new Options(), handler) { Providers = [new TestProvider()] };

        var actual = await embed.EmbedAsync("https://example.com/video/1");

        actual.Type.Should().Be(ResponseType.Rich);
        actual.Html.Should().Contain("""src="https://example.com/video/1" """.TrimEnd());
        handler.Requests.Should().BeEmpty();
    }

    [Test]
    public async Task EmbedAsync_PassesHostUrlToProvider()
    {
        var embed = new OEmbed();

        (await embed.EmbedAsync("https://www.twitch.tv/therealknossi")).Should().BeNull();
        (await embed.EmbedAsync("https://www.twitch.tv/therealknossi", "localhost")).Html.Should().Contain("parent=localhost");
    }

    [Test]
    public async Task EmbedAsync_EndpointProvider_DeserializesResponse()
    {
        var handler = FakeHttpMessageHandler.Json(SpotifyJson);
        var url = UniqueSpotifyUrl();

        var actual = await new OEmbed(new Options { EnableCache = false }, handler).EmbedAsync(url);

        actual.Type.Should().Be(ResponseType.Rich);
        actual.Title.Should().Be("Song");
        actual.ProviderName.Should().Be("Spotify");
        actual.Html.Should().Be("<iframe></iframe>");
    }

    [Test]
    public async Task EmbedAsync_EndpointProvider_SendsEncodedUrlAndUserAgent()
    {
        var handler = FakeHttpMessageHandler.Json(SpotifyJson);
        var url = UniqueSpotifyUrl();

        await new OEmbed(new Options { EnableCache = false }, handler).EmbedAsync(url);

        var request = handler.Requests.Should().ContainSingle().Subject;
        request.Method.Should().Be(HttpMethod.Get);
        request.RequestUri.GetLeftPart(UriPartial.Path).Should().Be(new SpotifyProvider().Endpoint);
        request.RequestUri.Query.Should().Be($"?url={WebUtility.UrlEncode(url)}&format=json");
        request.Headers.UserAgent.ToString().Should().StartWith("OEmbed.Core/");
    }

    [TestCase(HttpStatusCode.NotFound)]
    [TestCase(HttpStatusCode.Forbidden)]
    [TestCase(HttpStatusCode.InternalServerError)]
    public async Task EmbedAsync_ErrorStatus_ReturnsNull(HttpStatusCode status)
    {
        var handler = FakeHttpMessageHandler.Json(SpotifyJson, status);

        (await new OEmbed(new Options(), handler).EmbedAsync(UniqueSpotifyUrl())).Should().BeNull();
    }

    [TestCase("<html>not json</html>")]
    [TestCase("{\"type\": ")]
    public async Task EmbedAsync_InvalidJson_ReturnsNull(string body)
    {
        var handler = FakeHttpMessageHandler.Json(body);

        (await new OEmbed(new Options(), handler).EmbedAsync(UniqueSpotifyUrl())).Should().BeNull();
    }

    [Test]
    public async Task EmbedAsync_EmptyBody_ReturnsNullAndDoesNotCache()
    {
        var handler = FakeHttpMessageHandler.Json(string.Empty);
        var embed = new OEmbed(new Options(), handler);
        var url = UniqueSpotifyUrl();

        (await embed.EmbedAsync(url)).Should().BeNull();
        (await embed.EmbedAsync(url)).Should().BeNull();

        handler.Requests.Should().HaveCount(2);
    }

    [Test]
    public async Task EmbedAsync_NetworkFailure_ReturnsNull()
    {
        var handler = FakeHttpMessageHandler.Throws(new HttpRequestException("boom"));

        (await new OEmbed(new Options(), handler).EmbedAsync(UniqueSpotifyUrl())).Should().BeNull();
    }

    [Test]
    public async Task EmbedAsync_CacheEnabled_RequestsEndpointOnce()
    {
        var handler = FakeHttpMessageHandler.Json(SpotifyJson);
        var url = UniqueSpotifyUrl();

        var first = await new OEmbed(new Options { EnableCache = true }, handler).EmbedAsync(url);
        var second = await new OEmbed(new Options { EnableCache = true }, handler).EmbedAsync(url);

        handler.Requests.Should().ContainSingle();
        second.Should().BeSameAs(first);
    }

    [Test]
    public async Task EmbedAsync_CacheDisabled_RequestsEndpointEveryTime()
    {
        var handler = FakeHttpMessageHandler.Json(SpotifyJson);
        var embed = new OEmbed(new Options { EnableCache = false }, handler);
        var url = UniqueSpotifyUrl();

        await embed.EmbedAsync(url);
        await embed.EmbedAsync(url);

        handler.Requests.Should().HaveCount(2);
    }

    [Test]
    public async Task EmbedAsync_FailedRequest_IsNotCached()
    {
        var url = UniqueSpotifyUrl();
        var failing = FakeHttpMessageHandler.Json("{}", HttpStatusCode.ServiceUnavailable);
        var working = FakeHttpMessageHandler.Json(SpotifyJson);

        (await new OEmbed(new Options(), failing).EmbedAsync(url)).Should().BeNull();
        (await new OEmbed(new Options(), working).EmbedAsync(url)).Should().NotBeNull();
    }
#endif
}
