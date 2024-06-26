﻿using Microsoft.Extensions.DependencyInjection;
using TuneTalk.Core.Interfaces.IServices;
using TuneTalk.Core.Services;

namespace TuneTalk.Core;

public static class ServiceExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISpotifyService, SpotifyService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ITagService, TagService>();
        
        return services;
    }
}