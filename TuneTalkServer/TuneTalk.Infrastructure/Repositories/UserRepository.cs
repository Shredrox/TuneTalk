using Microsoft.AspNetCore.Identity;
using TuneTalk.Core.Entities;
using TuneTalk.Core.Interfaces.IRepositories;

namespace TuneTalk.Infrastructure.Repositories;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<User?> GetUserByName(string name)
    {
        return await userManager.FindByNameAsync(name);
    }

    public async Task CreateUser(User user, string password)
    {
        await userManager.CreateAsync(user, password);
    }
}