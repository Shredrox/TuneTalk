namespace TuneTalk.Core.DTOs.Requests.Auth;

public record LoginRequest(
    string Email, 
    string Password);