namespace TuneTalk.Core.Interfaces.IServices;

public interface IAuthService
{
    Task<bool> Register(string name, string email, string password);
}