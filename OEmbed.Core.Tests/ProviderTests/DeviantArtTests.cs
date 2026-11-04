namespace OEmbed.Core.Tests.ProviderTests;

public class DeviantArtTests : IProviderTests
{
    [TestCase("https://www.deviantart.com/wlop/art/Sunshine2-905829772")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<DeviantArtProvider>(url);
    }

#if NET481
    [Category("Integration")]
    [Ignore("Ignore because it throws sometimes a 403")]
    [TestCase("https://www.deviantart.com/wlop/art/Sunshine2-905829772")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
    [Ignore("Ignore because it throws sometimes a 403")]
    [TestCase("https://www.deviantart.com/wlop/art/Sunshine2-905829772")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}