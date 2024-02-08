using Microsoft.AspNetCore.Mvc;
using TuneTalk.Core.DTOs.Requests;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
    {
        if (!await authService.Register(dto.Name, dto.Email, dto.Password))
        {
            return Conflict("Username is already taken");
        }
        
        return Created();
    }
}