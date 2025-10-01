# ServiceCollection Decorator Extensions

This repository provides **extension methods for `IServiceCollection`** with built-in support for service decorators.  
It allows you to easily register services with **1, 2, or 3 levels of decoration**, without writing boilerplate code.  

The solution follows the **Decorator design pattern**, making it possible to enhance existing services with additional behavior while keeping the code modular and maintainable.

---

## 📦 Features
- ✅ Extension methods for registering services with decorators  
- ✅ Support for **1, 2, or 3 levels** of decorators  
- ✅ Easy integration with `.NET Dependency Injection` (`Microsoft.Extensions.DependencyInjection`)  
- ✅ Clear and reusable API via static helper classes:  
  - `Decorator1ServiceCollectionExtensions`  
  - `Decorator2ServiceCollectionExtensions`  
  - `Decorator3ServiceCollectionExtensions`  
