namespace OEmbed.Core.Providers;

public record SketchfabProvider : Provider
{
    public SketchfabProvider()
    {
        this.Name = "Sketchfab";
        this.Hosts = ["sketchfab.com"];

        this.AddMatches(@"/(?:3d-models|models)/([a-zA-Z0-9-]+)/?(?:\?\S*)?");

        this.Endpoint = "https://sketchfab.com/oembed";
    }
}
