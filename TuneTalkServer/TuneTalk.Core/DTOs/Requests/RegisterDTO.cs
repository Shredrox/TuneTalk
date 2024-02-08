namespace TuneTalk.Core.DTOs.Requests;

public record RegisterDTO(
    string Name, 
    string Email, 
    string Password);