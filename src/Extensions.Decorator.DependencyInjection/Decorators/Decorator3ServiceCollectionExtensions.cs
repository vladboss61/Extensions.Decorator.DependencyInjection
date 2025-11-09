namespace Extensions.Decorator.DependencyInjection.Decorators;

using Microsoft.Extensions.DependencyInjection;

public static class Decorator3ServiceCollectionExtensions
{
    public static IServiceCollection AddDecorator<TInterface, TImplementation, TDecorator1, TDecorator2, TDecorator3>(
        this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TInterface : class
            where TImplementation : class, TInterface
            where TDecorator1 : class, TInterface
            where TDecorator2 : class, TInterface
            where TDecorator3 : class, TInterface
    {
        services.Add(new ServiceDescriptor(typeof(TImplementation), typeof(TImplementation), lifetime));

        services.Add(
            new ServiceDescriptor(
            typeof(TInterface),
                serviceProvider => ActivatorUtilities.CreateInstance<TDecorator3>(
                        serviceProvider, ActivatorUtilities.CreateInstance<TDecorator2>(
                            serviceProvider, ActivatorUtilities.CreateInstance<TDecorator1>(
                                serviceProvider, serviceProvider.GetRequiredService<TImplementation>()))),
                lifetime));

        return services;
    }

    public static IServiceCollection AddSingletonDecorator<TInterface, TImplementation, TDecorator1, TDecorator2, TDecorator3>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
        where TDecorator1 : class, TInterface
        where TDecorator2 : class, TInterface
        where TDecorator3 : class, TInterface
    {
        return services.AddDecorator<TInterface, TImplementation, TDecorator1, TDecorator2, TDecorator3>(ServiceLifetime.Singleton);
    }

    public static IServiceCollection AddScopedDecorator<TInterface, TImplementation, TDecorator1, TDecorator2, TDecorator3>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
        where TDecorator1 : class, TInterface
        where TDecorator2 : class, TInterface
        where TDecorator3 : class, TInterface
    {
        return services.AddDecorator<TInterface, TImplementation, TDecorator1, TDecorator2, TDecorator3>(ServiceLifetime.Scoped);
    }

    public static IServiceCollection AddTransientDecorator<TInterface, TImplementation, TDecorator1, TDecorator2, TDecorator3>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
        where TDecorator1 : class, TInterface
        where TDecorator2 : class, TInterface
        where TDecorator3 : class, TInterface
    {
        return services.AddDecorator<TInterface, TImplementation, TDecorator1, TDecorator2, TDecorator3>(ServiceLifetime.Transient);
    }
}
