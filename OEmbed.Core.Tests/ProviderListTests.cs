namespace OEmbed.Core.Tests;

using System.Linq;

public class ProviderListTests
{
    private static readonly List<Provider> Providers = ProviderList.GetProviders();

    private static IEnumerable<TestCaseData> AllProviders() =>
        Providers.Select(p => new TestCaseData(p).SetArgDisplayNames(p.Name));

    [Test]
    public void GetProviders_ReturnsEveryConcreteProviderOnce()
    {
        var expected = typeof(Provider).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Provider)) && !t.IsAbstract);

        Providers.Select(p => p.GetType()).Should().BeEquivalentTo(expected);
        Providers.Select(p => p.Name).Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void GetProviders_ReturnsFreshInstances()
    {
        ProviderList.GetProviders()[0].Should().NotBeSameAs(ProviderList.GetProviders()[0]);
    }

    [Test]
    public void Hosts_AreNotSharedBetweenProviders()
    {
        Providers.SelectMany(p => p.Hosts).Should().OnlyHaveUniqueItems();
    }

    [TestCaseSource(nameof(AllProviders))]
    public void Provider_IsWellFormed(Provider provider)
    {
        provider.Name.Should().NotBeNullOrWhiteSpace();
        provider.Hosts.Should().NotBeNullOrEmpty();
        provider.Hosts.Should().AllSatisfy(h => h.Should().NotBeNullOrWhiteSpace().And.Be(h.ToLowerInvariant()));
        provider.Matches.Should().NotBeEmpty();

        // Either the response comes from an oEmbed endpoint, or the provider renders its own HTML.
        if (string.IsNullOrEmpty(provider.Endpoint))
        {
            provider.Html.Should().NotBeNullOrWhiteSpace();
        }
        else
        {
            Uri.TryCreate(provider.Endpoint, UriKind.Absolute, out var endpoint).Should().BeTrue();
            endpoint.Scheme.Should().Be(Uri.UriSchemeHttps);
        }
    }

    [TestCaseSource(nameof(AllProviders))]
    public void Provider_DoesNotMatchForeignHost(Provider provider)
    {
        provider.CanHandleUrl(new Uri("https://unrelated-host.invalid/watch?v=1")).Should().BeFalse();
    }
}
