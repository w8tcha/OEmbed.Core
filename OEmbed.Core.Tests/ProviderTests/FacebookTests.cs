namespace OEmbed.Core.Tests.ProviderTests;

public class FacebookTests : IProviderTests
{
    
   [TestCase("https://www.facebook.com/iu.loen/posts/501755841318628")]
   [TestCase("https://www.facebook.com/iu.loen/photos/281842976643250")]
   [TestCase("https://www.facebook.com/photo.php?fbid=281842976643250&set=pb.100044526485652.-2207520000..&type=3")]
   [TestCase("https://www.facebook.com/photo/?fbid=3613461915406206&set=a.277059300454951")]
   [TestCase("https://www.facebook.com/iu.loen/videos/537284977236313")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://www.facebook.com/iu.loen/posts/501755841318628")] 
   [TestCase("https://www.facebook.com/iu.loen/photos/281842976643250")]
   [TestCase("https://www.facebook.com/photo.php?fbid=281842976643250&set=pb.100044526485652.-2207520000..&type=3")]
   [TestCase("https://www.facebook.com/photo/?fbid=3613461915406206&set=a.277059300454951")]
   [TestCase("https://www.facebook.com/iu.loen/videos/537284977236313")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }

#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://www.facebook.com/iu.loen/posts/501755841318628")]
   [TestCase("https://www.facebook.com/iu.loen/photos/281842976643250")]
   [TestCase("https://www.facebook.com/photo.php?fbid=281842976643250&set=pb.100044526485652.-2207520000..&type=3")]
   [TestCase("https://www.facebook.com/photo/?fbid=3613461915406206&set=a.277059300454951")]
   [TestCase("https://www.facebook.com/iu.loen/videos/537284977236313")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }
#endif
}