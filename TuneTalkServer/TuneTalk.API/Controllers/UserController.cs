using Microsoft.AspNetCore.Mvc;
using TuneTalk.Core.DTOs.Responses.User;
using TuneTalk.Core.Exceptions;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{search}")]
    public async Task<IActionResult> GetUsersBySearch(string search)
    {
        try
        {
            var users = await userService.SearchByName(search);
            var response = users
                .Select(user => new UserSearchResultResponse(user))
                .ToList();

            return Ok(response);
        }
        catch (NotFoundException e)
        {
            Console.WriteLine(e);
            return Ok(new List<UserSearchResultResponse>());
        }
    }
}