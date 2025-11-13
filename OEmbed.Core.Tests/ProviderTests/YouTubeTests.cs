namespace OEmbed.Core.Tests.ProviderTests;

public class YouTubeTests : IProviderTests
{
    [Theory]
    [InlineData("https://youtu.be/LKWFkELeYwc")]
    [InlineData("http://youtu.be/LKWFkELeYwc")]
    [InlineData("https://www.youtu.be/LKWFkELeYwc")]
    [InlineData("https://youtu.be/ZQKdayVotaI?list=RDS_Q-fOj9Mho")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc")]
    [InlineData("https://www.youtube.com/embed/LKWFkELeYwc?autoplay=1")]
    [InlineData("https://m.youtube.com/watch?v=LKWFkELeYwc&feature=youtu.be")]
    [InlineData("https://youtu.be/LKWFkELeYwc?t=5")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5s")]
    [InlineData("https://www.youtube.com/watch?v=GxmJBAIoWUo&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
    [InlineData("https://www.youtube.com/playlist?list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
    [InlineData("https://www.youtube.com/watch?v=Rol0iKEXk_8&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ&index=3")]
    [InlineData("https://www.youtube.com/shorts/8wAOnwoKHGI")]
    [InlineData("https://youtube.com/shorts/8wAOnwoKHGI?feature=share")]
    [InlineData("https://www.youtube.com/live/jfKfPfyJRdk?feature=share")]
    public void CanEmbedTest(string url)
    {
        var embed = new OEmbed();

        var canEmbed = embed.CanEmbed(url);

        Assert.True(canEmbed);
    }

#if NET481
    [Theory]
    [InlineData("https://youtu.be/LKWFkELeYwc")]
    [InlineData("http://youtu.be/LKWFkELeYwc")]
    [InlineData("https://youtu.be/ZQKdayVotaI?list=RDS_Q-fOj9Mho")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc")]
    [InlineData("https://m.youtube.com/watch?v=LKWFkELeYwc&feature=youtu.be")]
    [InlineData("https://youtu.be/LKWFkELeYwc?t=5")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5s")]
    [InlineData("https://www.youtube.com/watch?v=GxmJBAIoWUo&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
    [InlineData("https://www.youtube.com/playlist?list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
    [InlineData("https://www.youtube.com/watch?v=Rol0iKEXk_8&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ&index=3")]
    [InlineData("https://www.youtube.com/shorts/8wAOnwoKHGI")]
    [InlineData("https://youtube.com/shorts/8wAOnwoKHGI?feature=share")]
    [InlineData("https://www.youtube.com/live/jfKfPfyJRdk?feature=share")]
    public void EmbedTest(string url)
    {
        var embed = new OEmbed();

        var actual = embed.Embed(url);

        Assert.NotNull(actual);
    }
#endif

#if NET9_0_OR_GREATER
    [Theory]
    [InlineData("https://youtu.be/LKWFkELeYwc")]
    [InlineData("http://youtu.be/LKWFkELeYwc")]
    [InlineData("https://youtu.be/ZQKdayVotaI?list=RDS_Q-fOj9Mho")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc")]
    [InlineData("https://m.youtube.com/watch?v=LKWFkELeYwc&feature=youtu.be")]
    [InlineData("https://youtu.be/LKWFkELeYwc?t=5")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5")]
    [InlineData("https://www.youtube.com/watch?v=LKWFkELeYwc&t=5s")]
    [InlineData("https://www.youtube.com/watch?v=GxmJBAIoWUo&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
    [InlineData("https://www.youtube.com/playlist?list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ")]
    [InlineData("https://www.youtube.com/watch?v=Rol0iKEXk_8&list=PL8mPWv3h4qJcOYZn8iFMLga3DjAY5nQLQ&index=3")]
    [InlineData("https://www.youtube.com/shorts/8wAOnwoKHGI")]
    [InlineData("https://youtube.com/shorts/8wAOnwoKHGI?feature=share")]
    [InlineData("https://www.youtube.com/live/jfKfPfyJRdk?feature=share")]
    public async Task EmbedAsyncTest(string url)
    {
        var embed = new OEmbed();

        var actual = await embed.EmbedAsync(url);

        Assert.NotNull(actual);
    }

#endif
}