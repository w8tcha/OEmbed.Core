namespace OEmbed.Net.Tests.ProviderTests;

public class DailyMotionTests : IProviderTests
{
    [Theory]
    [InlineData("https://www.dailymotion.com/video/x87cx3z")]
    [InlineData("https://dai.ly/x87cx3z")]
    [InlineData("https://www.dailymotion.com/embed/video/x87cx3z?autoplay=1")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481
    [Theory]
    [InlineData("https://www.dailymotion.com/video/x87cx3z")]
    [InlineData("https://dai.ly/x87cx3z")]
    [InlineData("https://www.dailymotion.com/embed/video/x87cx3z?autoplay=1")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET6_0_OR_GREATER
    [Theory]
    [InlineData("https://www.dailymotion.com/video/x87cx3z")]
    [InlineData("https://dai.ly/x87cx3z")]
    [InlineData("https://www.dailymotion.com/embed/video/x87cx3z?autoplay=1")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}