using TuneTalk.Core.DTOs.Responses;

namespace TuneTalk.Core.Interfaces.IServices;

public interface ISpotifyService
{
    string GetSpotifyLoginUrl();
    Task<string> ExchangeCodeForToken(string code);
    Task<SpotifyProfileResponse> GetUserSpotifyProfile(string token);
}