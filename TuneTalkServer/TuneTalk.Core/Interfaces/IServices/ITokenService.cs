using TuneTalk.Core.Entities;

namespace TuneTalk.Core.Interfaces.IServices;

public interface ITokenService
{
    string CreateAccessToken(User user);
    Task<string> CreateRefreshToken(User user);
}