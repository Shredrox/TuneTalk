using TuneTalk.Core.Entities;

namespace TuneTalk.Core.Interfaces.IRepositories;

public interface IPostRepository
{
    Task CreatePost(Post post);
    Task<Post?> GetPostById(Guid id);
}