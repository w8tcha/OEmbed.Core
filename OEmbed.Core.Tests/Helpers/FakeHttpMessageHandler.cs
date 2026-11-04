#if NET9_0_OR_GREATER
namespace OEmbed.Core.Tests.Helpers;

using System.Net;
using System.Net.Http;
using System.Threading;

/// <summary>
/// An <see cref="HttpMessageHandler"/> that records requests and answers them with a canned response,
/// so <see cref="OEmbed"/> can be exercised without touching the network.
/// </summary>
public sealed class FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> respond) : HttpMessageHandler
{
    public List<HttpRequestMessage> Requests { get; } = [];

    public static FakeHttpMessageHandler Json(string json, HttpStatusCode status = HttpStatusCode.OK) =>
        new(_ => new HttpResponseMessage(status) { Content = new StringContent(json) });

    public static FakeHttpMessageHandler Throws(Exception exception) => new(_ => throw exception);

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        this.Requests.Add(request);
        return Task.FromResult(respond(request));
    }
}
#endif
