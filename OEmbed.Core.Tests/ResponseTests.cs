namespace OEmbed.Core.Tests;

using Newtonsoft.Json;

public class ResponseTests
{
    [TestCase(ResponseType.Video)]
    [TestCase(ResponseType.Rich)]
    public void Render_VideoAndRich_ReturnHtml(string type)
    {
        var response = new Response { Type = type, Html = "<iframe></iframe>" };

        response.Render().Should().Be("<iframe></iframe>");
    }

    [Test]
    public void Render_Photo_ReturnsImgTag()
    {
        var response = new Response { Type = ResponseType.Photo, Url = "https://img/x.png", Title = "Cat" };

        response.Render().Should().Be("<img src=\"https://img/x.png\" alt=\"Cat\" />");
    }

    [Test]
    public void Render_Link_UsesTitle()
    {
        var response = new Response
        {
            Type = ResponseType.Link, AuthorUrl = "https://author", Title = "Title", AuthorName = "Author"
        };

        response.Render().Should().Be("<a href=\"https://author\">Title</a>");
    }

    [Test]
    public void Render_Link_FallsBackToAuthorName()
    {
        var response = new Response { Type = ResponseType.Link, AuthorUrl = "https://author", AuthorName = "Author" };

        response.Render().Should().Be("<a href=\"https://author\">Author</a>");
    }

    [Test]
    public void Render_Photo_HtmlEncodesValues()
    {
        var response = new Response
        {
            Type = ResponseType.Photo,
            Url = "https://img/x.png?a=1&b=\"onerror=\"alert(1)",
            Title = "\"><script>alert(1)</script>"
        };

        response.Render().Should().Be(
            "<img src=\"https://img/x.png?a=1&amp;b=&quot;onerror=&quot;alert(1)\" alt=\"&quot;&gt;&lt;script&gt;alert(1)&lt;/script&gt;\" />");
    }

    [Test]
    public void Render_Link_HtmlEncodesValues()
    {
        var response = new Response
        {
            Type = ResponseType.Link, AuthorUrl = "https://author/?a=1&b=2", Title = "<b>Tom & Jerry</b>"
        };

        response.Render().Should().Be("<a href=\"https://author/?a=1&amp;b=2\">&lt;b&gt;Tom &amp; Jerry&lt;/b&gt;</a>");
    }

    [TestCase("javascript:alert(1)")]
    [TestCase("data:text/html;base64,PHNjcmlwdD4=")]
    [TestCase("/relative/path")]
    [TestCase(null)]
    public void Render_NonHttpUrls_AreDropped(string url)
    {
        new Response { Type = ResponseType.Link, AuthorUrl = url, Title = "T" }.Render()
            .Should().Be("<a href=\"\">T</a>");

        new Response { Type = ResponseType.Photo, Url = url, Title = "T" }.Render()
            .Should().Be("<img src=\"\" alt=\"T\" />");
    }

    [Test]
    public void Render_Photo_WithoutTitle_RendersEmptyAlt()
    {
        new Response { Type = ResponseType.Photo, Url = "http://img/x.png" }.Render()
            .Should().Be("<img src=\"http://img/x.png\" alt=\"\" />");
    }

    [TestCase("unknown")]
    [TestCase(null)]
    public void Render_UnknownTypeWithHtml_FallsBackToHtml(string type)
    {
        var response = new Response { Type = type, Html = "<div></div>" };

        response.Render().Should().Be("<div></div>");
    }

    [TestCase("unknown", null)]
    [TestCase(null, "")]
    public void Render_UnknownTypeWithoutHtml_Throws(string type, string html)
    {
        var response = new Response { Type = type, Html = html };

        var act = () => response.Render();

        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void Deserialize_MapsOEmbedFieldNames()
    {
        const string Json = """
                            {
                              "type": "video", "version": "1.0", "title": "T",
                              "author_name": "A", "author_url": "https://a",
                              "provider_name": "P", "provider_url": "https://p",
                              "cache_age": "3600",
                              "thumbnail_url": "https://t", "thumbnail_width": 480, "thumbnail_height": 360,
                              "url": "https://u", "html": "<iframe></iframe>",
                              "width": "640", "height": "480"
                            }
                            """;

        var response = JsonConvert.DeserializeObject<Response>(Json);

        response.Should().BeEquivalentTo(new Response
        {
            Type = "video",
            Version = "1.0",
            Title = "T",
            AuthorName = "A",
            AuthorUrl = "https://a",
            ProviderName = "P",
            ProviderUrl = "https://p",
            CacheAge = "3600",
            ThumbnailUrl = "https://t",
            ThumbnailWidth = 480,
            ThumbnailHeight = 360,
            Url = "https://u",
            Html = "<iframe></iframe>",
            Width = "640",
            Height = "480"
        });
    }
}
