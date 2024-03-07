using TuneTalk.Core.Entities;

namespace TuneTalk.Core.Interfaces.IRepositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserByName(string name);
    Task<List<string>> SearchByName(string name);
    Task CreateUser(User user, string password);
    Task UpdateUser(User user);
}