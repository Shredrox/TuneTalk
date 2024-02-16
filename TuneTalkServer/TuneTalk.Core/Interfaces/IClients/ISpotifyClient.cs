namespace TuneTalk.Core.Interfaces.IClients;

public interface ISpotifyClient
{
    Task<HttpResponseMessage> GetToken(FormUrlEncodedContent parameters);
    Task<HttpResponseMessage> GetUserInfo(string token);
    Task<HttpResponseMessage> GetUserTopArtists(string token);
    Task<HttpResponseMessage> GetUserTopSongs(string token);
}