namespace TuneTalk.Core.DTOs.Requests.Auth;

public record RegisterRequest(
    string Name, 
    string Email, 
    string Password);