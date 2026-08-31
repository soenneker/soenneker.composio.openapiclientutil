[![](https://img.shields.io/nuget/v/soenneker.composio.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.composio.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.composio.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.composio.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.composio.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.composio.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.composio.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.composio.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Composio.OpenApiClientUtil

Provides a lazily created, cached Composio OpenAPI client backed by `Soenneker.Composio.HttpClients`.

## Installation

```bash
dotnet add package Soenneker.Composio.OpenApiClientUtil
```

## Configuration

```json
{
  "Composio": {
    "ApiKey": "your-project-api-key"
  }
}
```

The underlying HTTP provider sends the key in `x-api-key` and targets `https://backend.composio.dev`. See `Soenneker.Composio.HttpClients` for the optional header-template and base-address overrides.

## Registration

```csharp
using Soenneker.Composio.OpenApiClientUtil.Registrars;

services.AddComposioOpenApiClientUtilAsScoped();
```

Use `AddComposioOpenApiClientUtilAsSingleton()` when one cached generated client should be shared by the application.

## Usage

```csharp
using Soenneker.Composio.OpenApiClient;
using Soenneker.Composio.OpenApiClientUtil.Abstract;

public sealed class ToolkitService
{
    private readonly IComposioOpenApiClientUtil _clients;

    public ToolkitService(IComposioOpenApiClientUtil clients)
    {
        _clients = clients;
    }

    public async Task List(CancellationToken cancellationToken)
    {
        ComposioOpenApiClient client = await _clients.Get(cancellationToken);

        var result = await client.Api.V3.Toolkits.GetAsync(request =>
        {
            request.QueryParameters.Limit = 50;
        }, cancellationToken);
    }
}
```

Each utility instance caches one generated client. Both registrations use a singleton HTTP provider; a scoped utility can therefore be discarded without disposing the shared `HttpClient`. The HTTP provider remains responsible for that client's lifetime and disposes it when the application container shuts down.
