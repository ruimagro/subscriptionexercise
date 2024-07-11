using Crayon.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crayon.Repository.Infrastructure;

public static class ConfigureDependencyInjection
{
    public static IServiceCollection AddRepositoryInfrastructure(this IServiceCollection services)
    {
        // TODO: Use IOptions
        services.AddDbContext<CrayonDbContext>(options =>
            options.UseSqlServer("""
                                 Data Source=localhost;
                                 Initial Catalog=CrayonDB;
                                 User Id=sa;
                                 Password=SecretPassword123!;
                                 TrustServerCertificate=True;
                                 """));
        
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider 
            => serviceProvider.GetRequiredService<CrayonDbContext>());
        
        return services;
    }
}