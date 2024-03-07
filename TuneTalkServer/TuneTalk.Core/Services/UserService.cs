using Microsoft.IdentityModel.Tokens;
using TuneTalk.Core.Entities;
using TuneTalk.Core.Exceptions;
using TuneTalk.Core.Interfaces.IRepositories;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.Core.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User?> GetUserByName(string name)
    {
        return await userRepository.GetUserByName(name);
    }

    public async Task<List<string>> SearchByName(string name)
    { 
        var users = await userRepository.SearchByName(name);
        
        if (users.IsNullOrEmpty())
        {
            throw new NotFoundException("No users found");
        }
        
        return users;
    }
}