using System.Net.Http.Headers;
using TuneTalk.Core.Interfaces.IClients;

namespace TuneTalk.Infrastructure.Clients;

public class SpotifyClient(HttpClient httpClient) : ISpotifyClient
{
    public async Task<HttpResponseMessage> GetToken(FormUrlEncodedContent parameters)
    {
        const string tokenEndpoint = "https://accounts.spotify.com/api/token";
        
        return await httpClient.PostAsync(tokenEndpoint, parameters);
    }

    public async Task<HttpResponseMessage> GetUserInfo(string token)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await httpClient.GetAsync("https://api.spotify.com/v1/me");
    }
}