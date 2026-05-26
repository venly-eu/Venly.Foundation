using Application.Common;
using Application.Contracts.Queries;
using Application.Contracts.Repositories;
using Infrastructure.Accounts;
using Infrastructure.Configuration;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, AppSettings settings)
    {
        services.AddScoped<IAccountQueries, AccountQueries>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var connectionString = settings.ConnectionStrings.DatabaseConnectionString;
        services.AddDbContextFactory<ApplicationDbContext>((options) => options.UseSqlServer(connectionString));

        return services;
    }
}