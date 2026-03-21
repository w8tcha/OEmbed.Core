namespace OEmbed.Core.Tests;

public class ValidUrlTests
{
#if NET481
    [TestCase("testing")]
    public void NotValidUrlTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().BeNull();
    }
#endif

#if NET9_0_OR_GREATER
    [TestCase("testing")]
    public async Task NotValidUrlTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().BeNull();
    }
#endif
}