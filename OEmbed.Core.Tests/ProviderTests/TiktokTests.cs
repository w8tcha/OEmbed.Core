namespace OEmbed.Core.Tests.ProviderTests;

public class TikTokTests : IProviderTests
{
    
   [TestCase("https://m.tiktok.com/v/6934593663062265094.html")]
   [TestCase("https://www.tiktok.com/@faaaariii_/video/6934593663062265094")]
   [TestCase("https://www.tiktok.com/@faaaariii_/video/6934593663062265094?is_copy_url=1&is_from_webapp=v1")]
   [TestCase("https://www.tiktok.com/@faaaariii_")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<TikTokProvider>(url);
    }

#if NET481
    [Category("Integration")]
    
   [TestCase("https://m.tiktok.com/v/6934593663062265094.html")]
   [TestCase("https://www.tiktok.com/@faaaariii_/video/6934593663062265094")]
   [TestCase("https://www.tiktok.com/@faaaariii_/video/6934593663062265094?is_copy_url=1&is_from_webapp=v1")]
   [TestCase("https://www.tiktok.com/@faaaariii_")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
    
   [TestCase("https://m.tiktok.com/v/6934593663062265094.html")]
   [TestCase("https://www.tiktok.com/@faaaariii_/video/6934593663062265094")]
   [TestCase("https://www.tiktok.com/@faaaariii_/video/6934593663062265094?is_copy_url=1&is_from_webapp=v1")]
   [TestCase("https://www.tiktok.com/@faaaariii_")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}