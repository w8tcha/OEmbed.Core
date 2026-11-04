#if NET9_0_OR_GREATER
namespace OEmbed.Core.Tests;

using Microsoft.Extensions.DependencyInjection;

using global::OEmbed.Core.Extensions;
using global::OEmbed.Core.Interfaces;

public class ServiceCollectionExtensionsTests
{
    [Test]
    public void AddOEmbed_RegistersScopedIOEmbed()
    {
        var services = new ServiceCollection();

        services.AddOEmbed().Should().BeSameAs(services);

        var descriptor = services.Should().ContainSingle(d => d.ServiceType == typeof(IOEmbed)).Subject;
        descriptor.Lifetime.Should().Be(ServiceLifetime.Scoped);

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        var first = scope.ServiceProvider.GetRequiredService<IOEmbed>();

        first.Should().BeOfType<OEmbed>();
        scope.ServiceProvider.GetRequiredService<IOEmbed>().Should().BeSameAs(first);

        using var otherScope = provider.CreateScope();
        otherScope.ServiceProvider.GetRequiredService<IOEmbed>().Should().NotBeSameAs(first);
    }

    [Test]
    public void AddOEmbed_InvokesConfigureCallbackOnce()
    {
        var calls = 0;
        Options captured = null;

        new ServiceCollection().AddOEmbed(o =>
        {
            calls++;
            captured = o;
            o.EnableCache = false;
        });

        calls.Should().Be(1);
        captured.EnableCache.Should().BeFalse();
    }

    [Test]
    public void AddOEmbed_NullServices_Throws()
    {
        IServiceCollection services = null;

        var act = () => services.AddOEmbed();

        act.Should().Throw<ArgumentNullException>();
    }
}
#endif
