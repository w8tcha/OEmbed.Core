namespace OEmbed.Core.Tests.ProviderTests;

public class VimeoTests : IProviderTests
{
    
   [TestCase("https://vimeo.com/22439234")]
   [TestCase("https://vimeo.com/22439234?embedded=true&source=video_title&owner=910279")]
   [TestCase("https://vimeo.com/groups/musicvideo/videos/306797894")]
   [TestCase("https://vimeo.com/channels/music/244199526")]
   [TestCase("https://vimeo.com/terjes/themountain")]
   [TestCase("https://vimeo.com/terjes/themountain#t=5s")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://vimeo.com/22439234")]
   [TestCase("https://vimeo.com/22439234?embedded=true&source=video_title&owner=910279")]
   [TestCase("https://vimeo.com/groups/musicvideo/videos/306797894")]
   [TestCase("https://vimeo.com/channels/music/244199526")]
   [TestCase("https://vimeo.com/terjes/themountain")]
   [TestCase("https://vimeo.com/terjes/themountain#t=5s")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://vimeo.com/22439234")]
   [TestCase("https://vimeo.com/22439234?embedded=true&source=video_title&owner=910279")]
   [TestCase("https://vimeo.com/groups/musicvideo/videos/306797894")]
   [TestCase("https://vimeo.com/channels/music/244199526")]
   [TestCase("https://vimeo.com/terjes/themountain")]
   [TestCase("https://vimeo.com/terjes/themountain#t=5s")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}