using TuneTalk.Core.DTOs.Requests.Post;
using TuneTalk.Core.Entities;
using TuneTalk.Core.Interfaces.IRepositories;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.Core.Services;

public class PostService(IPostRepository postRepository) : IPostService
{
    public async Task CreatePost(CreatePostRequest request)
    {
        var newPost = new Post
        {
            Title = request.Name,
            Content = request.Content
        };
        
        await postRepository.CreatePost(newPost);
    }
}