namespace TuneTalk.Core.DTOs.Responses.Auth;

public record LoginResponse(
    string? Username,
    string AccessToken, 
    string RefreshToken);