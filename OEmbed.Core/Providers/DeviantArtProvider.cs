namespace OEmbed.Core.Providers;

public record DeviantArtProvider : Provider
{
    public DeviantArtProvider()
    {
        this.Name = "DeviantArt";
        this.Hosts = ["www.deviantart.com", "deviantart.com", "fav.me", "sta.sh"];

        this.AddMatches(
            /*
             * https://www.deviantart.com/{author_name}/art/{id}
             * https://www.deviantart.com/art/{id}
             */
            @"/(?:[a-z0-9-_]+/)?art/([\S]+)/?",
            /*
             * https://fav.me/{id}
             * https://sta.sh/{id}
             */
            "/([a-zA-Z0-9]+)/?");

        this.Endpoint = "https://backend.deviantart.com/oembed";
    }
}