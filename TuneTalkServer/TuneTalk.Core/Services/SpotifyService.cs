using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TuneTalk.Core.DTOs.Responses;
using TuneTalk.Core.Exceptions;
using TuneTalk.Core.Interfaces.IClients;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.Core.Services;

public class SpotifyService(ISpotifyClient spotifyClient, IConfiguration configuration) : ISpotifyService
{
    private const string SpotifyRedirectUri = "http://localhost:5053/api/Spotify/callback";

    public string GetSpotifyLoginUrl()
    {
        var state = GenerateRandomString(16);
        const string scope = "user-read-private user-read-email user-top-read";

        var redirectUrl = $"https://accounts.spotify.com/authorize?" +
                          $"response_type=code" +
                          $"&client_id={configuration["SpotifyApi:ClientId"]}" +
                          $"&scope={scope}" +
                          $"&redirect_uri={SpotifyRedirectUri}" +
                          $"&state={state}";

        return redirectUrl;
    }

    public async Task<string> ExchangeCodeForToken(string code)
    {
        var parameters = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string?>("grant_type", "authorization_code"),
            new KeyValuePair<string, string?>("code", code),
            new KeyValuePair<string, string?>("redirect_uri", SpotifyRedirectUri),
            new KeyValuePair<string, string?>("client_id", configuration["SpotifyApi:ClientId"]),
            new KeyValuePair<string, string?>("client_secret", configuration["SpotifyApi:ClientSecret"])
        });
            
        try
        {
            var response = await spotifyClient.GetToken(parameters);
            var content = await response.Content.ReadAsStringAsync();

            var accessToken = content.Split('"')[3];
            return accessToken;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("rip");
            throw;
        }
    }

    public async Task<SpotifyProfileResponse> GetUserSpotifyProfile(string token)
    {
        try
        {
            var response = await spotifyClient.GetUserInfo(token);

            if (!response.IsSuccessStatusCode)
            {
                throw new SpotifyApiException("Error retrieving Spotify user data");
            }
            
            var user = JsonConvert.DeserializeObject<SpotifyProfileResponse>(await response.Content.ReadAsStringAsync());

            return user ?? throw new JsonSerializationException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    private static string GenerateRandomString(int length)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}