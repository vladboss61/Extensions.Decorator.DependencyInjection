using System;
using System.Threading.Tasks;

namespace Extensions.Decorator.DependencyInjection.Examples;

public sealed class RetryDecoratorUserRepository : IUserRepository
{
    private const int RetryMaxAttempts = 10;
    private readonly IUserRepository _userRepository;

    public RetryDecoratorUserRepository(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void ChangeUserAsync()
    {
        int attempts = 1;

        while (attempts <= RetryMaxAttempts)
        {
            Console.WriteLine($"Attempt: {attempts}");

            try
            {
                _userRepository.ChangeUserAsync();
                return;
            }
            catch (Exception ex)
            {
                attempts++;
                Task.Delay(1000);
            }
        }
    }
}
