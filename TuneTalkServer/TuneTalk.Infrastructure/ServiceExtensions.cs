using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TuneTalk.Core.Entities;
using TuneTalk.Core.Interfaces.IRepositories;
using TuneTalk.Infrastructure.Data;
using TuneTalk.Infrastructure.Repositories;

namespace TuneTalk.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TuneTalkDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("TuneTalkDb")));

        services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
        services.AddAuthorizationBuilder();
        
        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<TuneTalkDbContext>()
            .AddApiEndpoints();

        services.AddTransient<IUserRepository, UserRepository>();
        
        return services;
    }
}