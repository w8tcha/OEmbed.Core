namespace OEmbed.Core.Providers;

public record PinterestProvider : Provider
{
    public PinterestProvider()
    {
        this.Name = "Pinterest";
        this.Hosts =
        [
            "pinterest.ca", "www.pinterest.ca",
            "pinterest.cl", "www.pinterest.cl",
            "pinterest.co.kr", "www.pinterest.co.kr",
            "pinterest.co.uk", "www.pinterest.co.uk",
            "pinterest.com", "www.pinterest.com",
            "pinterest.com.au", "www.pinterest.com.au",
            "pinterest.com.mx", "www.pinterest.com.mx",
            "pinterest.de", "www.pinterest.de",
            "pinterest.dk", "www.pinterest.dk",
            "pinterest.es", "www.pinterest.es",
            "pinterest.fr", "www.pinterest.fr",
            "pinterest.jp", "www.pinterest.jp",
            "pinterest.nz", "www.pinterest.nz",
            "pinterest.pt", "www.pinterest.pt",
            "pinterest.ru", "www.pinterest.ru",
            "pinterest.se", "www.pinterest.se"
        ];

        this.AddMatches(@"/pin/([\d]+)/?");

        this.Endpoint = "https://www.pinterest.com/oembed.json";
    }
}