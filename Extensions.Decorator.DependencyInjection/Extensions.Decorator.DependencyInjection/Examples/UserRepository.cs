using System;

namespace Extensions.Decorator.DependencyInjection.Examples;

public class UserRepository : IUserRepository
{
    public void ChangeUserAsync()
    {
        // Example.
        //throw new InvalidOperationException("User changed in wrong way.");

        Console.WriteLine("User changing logic.");
    }
}