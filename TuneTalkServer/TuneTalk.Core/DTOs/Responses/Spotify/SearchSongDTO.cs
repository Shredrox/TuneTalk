namespace TuneTalk.Core.DTOs.Responses.Spotify;

public record SearchSongDTO(
    string Id,
    string Name, 
    string Artist,
    string AlbumArt);