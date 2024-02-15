using TuneTalk.Core.DTOs.Responses.Auth;

namespace TuneTalk.Core.Interfaces.IServices;

public interface IAuthService
{
    Task Register(string name, string email, string password);
    Task<LoginResponse> Login(string email, string password);
}