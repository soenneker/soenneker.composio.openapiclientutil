using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Composio.HttpClients.Abstract;
using Soenneker.Composio.OpenApiClientUtil.Abstract;
using Soenneker.Composio.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Composio.OpenApiClientUtil;

///<inheritdoc cref="IComposioOpenApiClientUtil"/>
public sealed class ComposioOpenApiClientUtil : IComposioOpenApiClientUtil
{
    private readonly AsyncSingleton<ComposioOpenApiClient> _client;

    public ComposioOpenApiClientUtil(IComposioOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ComposioOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Composio:ApiKey");
            string authHeaderValueTemplate = configuration["Composio:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new ComposioOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<ComposioOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
