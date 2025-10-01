namespace Extensions.Decorator.DependencyInjection.Decorators;

using Microsoft.Extensions.DependencyInjection;

public static class Decorator1ServiceCollectionExtensions
{
    public static IServiceCollection AddDecorator<TInterface, TImplementation, TDecorator1>(
        this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TInterface : class
            where TImplementation : class, TInterface
            where TDecorator1 : class, TInterface
    {
        services.Add(new ServiceDescriptor(typeof(TImplementation), typeof(TImplementation), lifetime));

        services.Add(
            new ServiceDescriptor(
                typeof(TInterface),
                serviceProvider =>
                    ActivatorUtilities.CreateInstance<TDecorator1>(
                        serviceProvider,
                        serviceProvider.GetRequiredService<TImplementation>()),
                lifetime));

        return services;
    }

    public static IServiceCollection AddSingletonDecorator<TInterface, TImplementation, TDecorator1>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
        where TDecorator1 : class, TInterface
    {
        return services.AddDecorator<TInterface, TImplementation, TDecorator1>(ServiceLifetime.Singleton);
    }

    public static IServiceCollection AddScopedDecorator<TInterface, TImplementation, TDecorator1>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
        where TDecorator1 : class, TInterface
    {
        return services.AddDecorator<TInterface, TImplementation, TDecorator1>(ServiceLifetime.Scoped);
    }

    public static IServiceCollection AddTransientDecorator<TInterface, TImplementation, TDecorator1>(this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
        where TDecorator1 : class, TInterface
    {
        return services.AddDecorator<TInterface, TImplementation, TDecorator1>(ServiceLifetime.Transient);
    }
}
