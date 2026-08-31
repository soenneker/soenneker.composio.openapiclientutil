using Soenneker.Composio.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Composio.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached <see cref="ComposioOpenApiClient"/> configured for the Composio API.
/// </summary>
public interface IComposioOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the client cached by this utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Composio client.</returns>
    ValueTask<ComposioOpenApiClient> Get(CancellationToken cancellationToken = default);
}
