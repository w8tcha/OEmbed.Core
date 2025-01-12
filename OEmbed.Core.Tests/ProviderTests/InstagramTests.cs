namespace OEmbed.Core.Tests.ProviderTests;

public class InstagramTests : IProviderTests
{
    [Theory]
    [InlineData("https://www.instagram.com/dlwlrma/")]
    [InlineData("https://www.instagram.com/p/1XSKgBAGz-/")]
    [InlineData("https://www.instagram.com/tv/CHLVnWVAF9I/")]
    [InlineData("https://www.instagram.com/reel/CW0gZu2rouF/")]
    [InlineData("https://www.instagram.com/p/1XSKgBAGz-/?utm_source=ig_web_button_share_sheet")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481
    [Theory]
    [InlineData("https://www.instagram.com/dlwlrma/")]
    [InlineData("https://www.instagram.com/p/1XSKgBAGz-/")]
    [InlineData("https://www.instagram.com/tv/CHLVnWVAF9I/")]
    [InlineData("https://www.instagram.com/reel/CW0gZu2rouF/")]
    [InlineData("https://www.instagram.com/p/1XSKgBAGz-/?utm_source=ig_web_button_share_sheet")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }

#endif

#if NET8_0_OR_GREATER
    [Theory]
    [InlineData("https://www.instagram.com/dlwlrma/")]
    [InlineData("https://www.instagram.com/p/1XSKgBAGz-/")]
    [InlineData("https://www.instagram.com/tv/CHLVnWVAF9I/")]
    [InlineData("https://www.instagram.com/reel/CW0gZu2rouF/")]
    [InlineData("https://www.instagram.com/p/1XSKgBAGz-/?utm_source=ig_web_button_share_sheet")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }
#endif
}