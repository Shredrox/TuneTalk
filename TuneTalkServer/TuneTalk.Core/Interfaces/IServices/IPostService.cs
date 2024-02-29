using TuneTalk.Core.DTOs.Requests.Post;

namespace TuneTalk.Core.Interfaces.IServices;

public interface IPostService
{
    Task CreatePost(CreatePostRequest post);
}