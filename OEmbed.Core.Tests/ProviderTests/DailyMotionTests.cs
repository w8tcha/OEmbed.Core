namespace OEmbed.Core.Tests.ProviderTests;

public class DailyMotionTests : IProviderTests
{
    
   [TestCase("https://www.dailymotion.com/video/x87cx3z")]
   [TestCase("https://dai.ly/x87cx3z")]
   [TestCase("https://www.dailymotion.com/embed/video/x87cx3z?autoplay=1")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://www.dailymotion.com/video/x87cx3z")]
   [TestCase("https://dai.ly/x87cx3z")]
   [TestCase("https://www.dailymotion.com/embed/video/x87cx3z?autoplay=1")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://www.dailymotion.com/video/x87cx3z")]
   [TestCase("https://dai.ly/x87cx3z")]
   [TestCase("https://www.dailymotion.com/embed/video/x87cx3z?autoplay=1")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}