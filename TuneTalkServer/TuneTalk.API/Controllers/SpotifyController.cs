using Microsoft.AspNetCore.Mvc;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpotifyController(ISpotifyService spotifyService) : ControllerBase
{
    [HttpGet("login")]
    public IActionResult SpotifyLogin()
    {
        var redirectUrl = spotifyService.GetSpotifyLoginUrl();
        return Redirect(redirectUrl);
    }
        
    [HttpGet("callback")]
    public async Task<IActionResult> Callback(string code, string state)
    {
        var accessToken = await spotifyService.ExchangeCodeForToken(code);
        
        Response.Cookies.Append("AccessToken", accessToken, new CookieOptions
        {
            Expires = DateTime.Now.AddMinutes(15),
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            Domain = "localhost",
            SameSite = SameSiteMode.None
        });
        
        return Ok(accessToken);
    }
    
    [HttpGet("profile")]
    public async Task<IActionResult> GetUserSpotifyProfile()
    {
        var accessToken = Request.Cookies["AccessToken"];
        if (string.IsNullOrEmpty(accessToken))
        {
            return BadRequest("Access token is required");
        }

        var profile = await spotifyService.GetUserSpotifyProfile(accessToken);
        
        return Ok(profile);
    }
}