using TuneTalk.Core.DTOs.Responses.Spotify;

namespace TuneTalk.Core.Interfaces.IServices;

public interface ISpotifyService
{
    string GetSpotifyLoginUrl();
    Task<string> ExchangeCodeForToken(string code);
    Task<SpotifyProfileDTO> GetUserSpotifyProfile(string token);
    Task<List<TopArtistDTO>> GetUserTopArtists(string token);
    Task<List<TopSongDTO>> GetUserTopSongs(string token);
}