namespace OEmbed.Core.Tests.ProviderTests;

public class GettyImagesTests : IProviderTests
{
   [TestCase("http://gty.im/74917285")]
    public void CanEmbedTest(string url)
    {
        ProviderAssert.Handles<GettyImagesProvider>(url);
    }

#if NET481
    [Category("Integration")]
   [TestCase("http://gty.im/74917285")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [Category("Integration")]
   [TestCase("http://gty.im/74917285")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}
