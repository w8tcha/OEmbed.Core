namespace OEmbed.Core.Tests;

public class ValidUrlTests
{
#if NET481
    [Theory]
    [InlineData("testing")]
    public void NotValidUrlTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.Null(actual);
    }
#endif

#if NET8_0_OR_GREATER
    [Theory]
    [InlineData("testing")]
    public async Task NotValidUrlTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.Null(actual);
    }
#endif
}