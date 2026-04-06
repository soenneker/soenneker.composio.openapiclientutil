using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Composio.HttpClients.Registrars;
using Soenneker.Composio.OpenApiClientUtil.Abstract;

namespace Soenneker.Composio.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class ComposioOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ComposioOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddComposioOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddComposioOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IComposioOpenApiClientUtil, ComposioOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ComposioOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddComposioOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddComposioOpenApiHttpClientAsSingleton()
                .TryAddScoped<IComposioOpenApiClientUtil, ComposioOpenApiClientUtil>();

        return services;
    }
}
