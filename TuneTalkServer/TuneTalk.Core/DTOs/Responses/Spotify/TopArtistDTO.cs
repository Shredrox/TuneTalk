namespace TuneTalk.Core.DTOs.Responses.Spotify;

public record TopArtistDTO(
    string Name,
    int Popularity,
    string Image);