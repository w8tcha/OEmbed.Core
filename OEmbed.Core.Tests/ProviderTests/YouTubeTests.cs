namespace OEmbed.Core.Tests.ProviderTests;

public class YouTubeTests : IProviderTests
{
    
   [TestCase("https://youtu.be/LKWFkELeYwc")]
   [TestCase("http://youtu.be/LKWFkELeYwc")]
   [TestCase("https://www.youtu.be/LKWFkELeYwc")]
   [TestCase("https://youtu.be/ZQKdayVotaI?list=RDS_Q-fOj9Mho")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc")]
   [TestCase("https://www.youtube.com/embed/LKWFkELeYwc?autoplay=1")]
   [TestCase("https://m.youtube.com/watch?v=LKWFkELeYwc&feature=youtu.be")]
   [TestCase("https://youtu.be/LKWFkELeYwc?t=5")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5s")]
   [TestCase("https://www.youtube.com/watch?v=GxmJBAIoWUo&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
   [TestCase("https://www.youtube.com/playlist?list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
   [TestCase("https://www.youtube.com/watch?v=Rol0iKEXk_8&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ&index=3")]
   [TestCase("https://www.youtube.com/shorts/8wAOnwoKHGI")]
   [TestCase("https://youtube.com/shorts/8wAOnwoKHGI?feature=share")]
   [TestCase("https://www.youtube.com/live/jfKfPfyJRdk?feature=share")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        canEmbed.Should().BeTrue();
    }

#if NET481
    
   [TestCase("https://youtu.be/LKWFkELeYwc")]
   [TestCase("http://youtu.be/LKWFkELeYwc")]
   [TestCase("https://youtu.be/ZQKdayVotaI?list=RDS_Q-fOj9Mho")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc")]
   [TestCase("https://m.youtube.com/watch?v=LKWFkELeYwc&feature=youtu.be")]
   [TestCase("https://youtu.be/LKWFkELeYwc?t=5")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5s")]
   [TestCase("https://www.youtube.com/watch?v=GxmJBAIoWUo&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
   [TestCase("https://www.youtube.com/playlist?list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
   [TestCase("https://www.youtube.com/watch?v=Rol0iKEXk_8&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ&index=3")]
   [TestCase("https://www.youtube.com/shorts/8wAOnwoKHGI")]
   [TestCase("https://youtube.com/shorts/8wAOnwoKHGI?feature=share")]
   [TestCase("https://www.youtube.com/live/jfKfPfyJRdk?feature=share")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        actual.Should().NotBeNull();
    }
#endif

#if NET9_0_OR_GREATER
    
   [TestCase("https://youtu.be/LKWFkELeYwc")]
   [TestCase("http://youtu.be/LKWFkELeYwc")]
   [TestCase("https://youtu.be/ZQKdayVotaI?list=RDS_Q-fOj9Mho")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc")]
   [TestCase("https://m.youtube.com/watch?v=LKWFkELeYwc&feature=youtu.be")]
   [TestCase("https://youtu.be/LKWFkELeYwc?t=5")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5")]
   [TestCase("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5s")]
   [TestCase("https://www.youtube.com/watch?v=GxmJBAIoWUo&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
   [TestCase("https://www.youtube.com/playlist?list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
   [TestCase("https://www.youtube.com/watch?v=Rol0iKEXk_8&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ&index=3")]
   [TestCase("https://www.youtube.com/shorts/8wAOnwoKHGI")]
   [TestCase("https://youtube.com/shorts/8wAOnwoKHGI?feature=share")]
   [TestCase("https://www.youtube.com/live/jfKfPfyJRdk?feature=share")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        actual.Should().NotBeNull();
    }

#endif
}