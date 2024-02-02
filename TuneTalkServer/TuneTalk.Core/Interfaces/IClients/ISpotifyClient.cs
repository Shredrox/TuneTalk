namespace TuneTalk.Core.Interfaces.IClients;

public interface ISpotifyClient
{
    Task<HttpResponseMessage> GetToken(FormUrlEncodedContent parameters);
    Task<HttpResponseMessage> GetUserInfo(string token);
}