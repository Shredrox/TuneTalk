using Microsoft.AspNetCore.Mvc;
using TuneTalk.Core.DTOs.Requests.Post;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController(IPostService postService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
    {
        try
        {
            await postService.CreatePost(request);
            return Created();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}