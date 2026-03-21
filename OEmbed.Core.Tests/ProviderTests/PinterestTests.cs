namespace OEmbed.Core.Tests.ProviderTests;

public class PinterestTests : IProviderTests
{
    
   [TestCase("https://www.pinterest.com/pin/6896205669260457/")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481

    
   [TestCase("https://www.pinterest.com/pin/6896205669260457/")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://www.pinterest.com/pin/6896205669260457/")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}