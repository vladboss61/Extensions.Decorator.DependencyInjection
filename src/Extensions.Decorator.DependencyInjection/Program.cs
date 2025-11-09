using Extensions.Decorator.DependencyInjection.Decorators;
using Extensions.Decorator.DependencyInjection.Examples;
using Microsoft.Extensions.DependencyInjection;

namespace Extensions.Decorator.DependencyInjection;

internal sealed class Program
{
    private static void Usage()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScopedDecorator<IUserRepository, UserRepository, RetryDecoratorUserRepository>();

        var serviceProvider = serviceCollection.BuildServiceProvider(
        new ServiceProviderOptions
        {
            // During BuildServiceProvider call, the ValidateOnBuild = true ensures that the service provider is validated at build time.
            // And get errors immediately if there are any issues with the service registrations. Comment out the line below to see the difference.
            // And comment serviceCollection.AddScoped<IServiceB, ServiceB>(); and add IServiceB to ServiceA constructor to see the error.
            //ValidateOnBuild = true,
            ValidateScopes = true
        });

        using var scope1 = serviceProvider.CreateScope();
        var userRepository = scope1.ServiceProvider.GetService<IUserRepository>();

        userRepository.ChangeUserAsync();
    }

    public static void Main(string[] args)
    {
        Usage();
    }
}

