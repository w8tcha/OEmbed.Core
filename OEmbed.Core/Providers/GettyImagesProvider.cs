namespace OEmbed.Core.Providers;

public record GettyImagesProvider : Provider
{
    public GettyImagesProvider()
    {
        this.Name = "GettyImages";
        this.Hosts = ["gettyimages.com", "www.gettyimages.com", "gty.im"];

        this.AddMatches(
            @"/detail/(?:photo/)?(?:[\w-]+)/(\d+)/?(?:\?\S*)?",
            @"/([a-zA-Z0-9]+)/?(?:\?\S*)?");

        this.Endpoint = "https://embed.gettyimages.com/oembed";
    }
}
