namespace OEmbed.Core.Tests.ProviderTests;

public class ImgurTests : IProviderTests
{
   [TestCase("https://imgur.com/VXH0cur")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<ImgurProvider>(url);
    }

#if NET481
    [Category("Integration")]
   [TestCase("https://imgur.com/VXH0cur")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
   [TestCase("https://imgur.com/VXH0cur")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
