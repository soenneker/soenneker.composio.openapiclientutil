using Soenneker.Composio.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Composio.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ComposioOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IComposioOpenApiClientUtil _openapiclientutil;

    public ComposioOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IComposioOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
