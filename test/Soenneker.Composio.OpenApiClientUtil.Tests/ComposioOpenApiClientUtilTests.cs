using Soenneker.Composio.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Composio.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class ComposioOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IComposioOpenApiClientUtil _openapiclientutil;

    public ComposioOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IComposioOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
