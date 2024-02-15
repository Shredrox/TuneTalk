using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TuneTalk.Core.Entities;
using TuneTalk.Core.Interfaces.IClients;
using TuneTalk.Core.Interfaces.IRepositories;
using TuneTalk.Infrastructure.Clients;
using TuneTalk.Infrastructure.Data;
using TuneTalk.Infrastructure.Repositories;

namespace TuneTalk.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TuneTalkDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("TuneTalkDb")));
        
        services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
        services.AddAuthorizationBuilder();

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<TuneTalkDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ISpotifyClient, SpotifyClient>();

        services.AddSignalR();

        return services;
    }
}