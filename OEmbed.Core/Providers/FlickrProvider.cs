namespace OEmbed.Core.Providers;

public record FlickrProvider : Provider
{
    public FlickrProvider()
    {
        this.Name = "Flickr";
        this.Hosts =
        [
            "www.flickr.com",
            "flickr.com",
            "flic.kr"
        ];

        this.AddMatches(
            @"/photos/(?:[@a-zA-Z0-9_\.\-]+)/([0-9]+)(?:/in/[^/\s]+)?/?/?",
            "/p/([a-zA-Z0-9]+)",
            @"/photos/([@a-zA-Z0-9_\.\-]+)(?:/(?:favorites|(?:albums|sets)/([0-9]+)))?/?");

        this.Endpoint = "https://www.flickr.com/services/oembed";
    }
}