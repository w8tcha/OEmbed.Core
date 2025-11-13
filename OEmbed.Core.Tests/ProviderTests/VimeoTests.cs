namespace OEmbed.Core.Tests.ProviderTests;

public class VimeoTests : IProviderTests
{
    [Theory]
    [InlineData("https://vimeo.com/22439234")]
    [InlineData("https://vimeo.com/22439234?embedded=true&source=video_title&owner=910279")]
    [InlineData("https://vimeo.com/groups/musicvideo/videos/306797894")]
    [InlineData("https://vimeo.com/channels/music/244199526")]
    [InlineData("https://vimeo.com/terjes/themountain")]
    [InlineData("https://vimeo.com/terjes/themountain#t=5s")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481
    [Theory]
    [InlineData("https://vimeo.com/22439234")]
    [InlineData("https://vimeo.com/22439234?embedded=true&source=video_title&owner=910279")]
    [InlineData("https://vimeo.com/groups/musicvideo/videos/306797894")]
    [InlineData("https://vimeo.com/channels/music/244199526")]
    [InlineData("https://vimeo.com/terjes/themountain")]
    [InlineData("https://vimeo.com/terjes/themountain#t=5s")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET9_0_OR_GREATER
    [Theory]
    [InlineData("https://vimeo.com/22439234")]
    [InlineData("https://vimeo.com/22439234?embedded=true&source=video_title&owner=910279")]
    [InlineData("https://vimeo.com/groups/musicvideo/videos/306797894")]
    [InlineData("https://vimeo.com/channels/music/244199526")]
    [InlineData("https://vimeo.com/terjes/themountain")]
    [InlineData("https://vimeo.com/terjes/themountain#t=5s")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}