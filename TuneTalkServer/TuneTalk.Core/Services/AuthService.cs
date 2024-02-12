using TuneTalk.Core.Entities;
using TuneTalk.Core.Interfaces.IRepositories;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.Core.Services;

public class AuthService(IUserRepository userRepository) : IAuthService
{
    public async Task<bool> Register(string name, string email, string password)
    {
        if (await userRepository.GetUserByName(name) != null)
        {
            return false;
        }
        
        var user = new User
        {
            UserName = name,
            Email = email
        };

        await userRepository.CreateUser(user, password);
        
        return true;
    }
}