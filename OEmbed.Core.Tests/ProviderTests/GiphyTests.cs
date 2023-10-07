namespace OEmbed.Core.Tests.ProviderTests;

public class GiphyTests : IProviderTests
{
    [Theory]
    [InlineData("https://giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
    [InlineData("https://www.giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
    [InlineData("https://media.giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
    [InlineData("https://giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
    [InlineData("https://giphy.com/clips/kpop-k-pop-red-velvet-UWq9DlocbqoIal7N7I")]
    [InlineData("http://giphy.com/embed/l2YWwjl8T5tdGiaf6")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481

    [Theory]
    [InlineData("https://giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
    [InlineData("https://www.giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
    [InlineData("https://media.giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
    [InlineData("https://giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
    [InlineData("https://giphy.com/clips/kpop-k-pop-red-velvet-UWq9DlocbqoIal7N7I")]
    [InlineData("http://giphy.com/embed/l2YWwjl8T5tdGiaf6")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET6_0_OR_GREATER
    [Theory]
    [InlineData("https://giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
    [InlineData("https://www.giphy.com/gifs/confused-iu-looking-up-l2YWwjl8T5tdGiaf6")]
    [InlineData("https://media.giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
    [InlineData("https://giphy.com/media/l2YWwjl8T5tdGiaf6/giphy.gif")]
    [InlineData("https://giphy.com/clips/kpop-k-pop-red-velvet-UWq9DlocbqoIal7N7I")]
    [InlineData("http://giphy.com/embed/l2YWwjl8T5tdGiaf6")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }

#endif
}