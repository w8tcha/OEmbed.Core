namespace OEmbed.Core.Tests.ProviderTests;

public class GiphyTests : IProviderTests
{
    
   [TestCase("https://giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
   [TestCase("https://www.giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
   [TestCase("https://media.giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
   [TestCase("https://giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
   [TestCase("https://giphy.com/clips/kpop-k-pop-red-velvet-UWq9DlocbqoIal7N7I")]
   [TestCase("http://giphy.com/embed/l2YWwjl8T5tdGiaf6")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481

    
   [TestCase("https://giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
   [TestCase("https://www.giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
   [TestCase("https://media.giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
   [TestCase("https://giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
   [TestCase("https://giphy.com/clips/kpop-k-pop-red-velvet-UWq9DlocbqoIal7N7I")]
   [TestCase("http://giphy.com/embed/l2YWwjl8T5tdGiaf6")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
   [TestCase("https://www.giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
   [TestCase("https://media.giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
   [TestCase("https://giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
   [TestCase("https://giphy.com/clips/kpop-k-pop-red-velvet-UWq9DlocbqoIal7N7I")]
   [TestCase("http://giphy.com/embed/l2YWwjl8T5tdGiaf6")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }

#endif
}