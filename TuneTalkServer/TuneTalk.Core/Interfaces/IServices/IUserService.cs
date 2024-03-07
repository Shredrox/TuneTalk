using TuneTalk.Core.Entities;

namespace TuneTalk.Core.Interfaces.IServices;

public interface IUserService
{
    Task<User?> GetUserByName(string name);
    Task<List<string>> SearchByName(string search);
}