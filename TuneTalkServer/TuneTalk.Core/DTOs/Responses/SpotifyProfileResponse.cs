namespace TuneTalk.Core.DTOs.Responses;

public class SpotifyProfileResponse
{
    public string Display_Name { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public Followers Followers { get; set; }
    public string Product { get; set; }
    public string Email { get; set; }
}

public class Image
{
    public string Url { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
}

public class Followers
{
    public int Total { get; set; }
}