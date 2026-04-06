using Soenneker.Composio.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Composio.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IComposioOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<ComposioOpenApiClient> Get(CancellationToken cancellationToken = default);
}
