namespace OEmbed.Core.Tests.ProviderTests;

public class InstagramTests : IProviderTests
{
    
   [TestCase("https://www.instagram.com/dlwlrma/")]
   [TestCase("https://www.instagram.com/p/1XSKgBAGz-/")]
   [TestCase("https://www.instagram.com/tv/CHLVnWVAF9I/")]
   [TestCase("https://www.instagram.com/reel/CW0gZu2rouF/")]
   [TestCase("https://www.instagram.com/p/1XSKgBAGz-/?utm_source=ig_web_button_share_sheet")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://www.instagram.com/dlwlrma/")]
   [TestCase("https://www.instagram.com/p/1XSKgBAGz-/")]
   [TestCase("https://www.instagram.com/tv/CHLVnWVAF9I/")]
   [TestCase("https://www.instagram.com/reel/CW0gZu2rouF/")]
   [TestCase("https://www.instagram.com/p/1XSKgBAGz-/?utm_source=ig_web_button_share_sheet")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }

#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://www.instagram.com/dlwlrma/")]
   [TestCase("https://www.instagram.com/p/1XSKgBAGz-/")]
   [TestCase("https://www.instagram.com/tv/CHLVnWVAF9I/")]
   [TestCase("https://www.instagram.com/reel/CW0gZu2rouF/")]
   [TestCase("https://www.instagram.com/p/1XSKgBAGz-/?utm_source=ig_web_button_share_sheet")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}