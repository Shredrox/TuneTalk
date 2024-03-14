using TuneTalk.Core.Entities;

namespace TuneTalk.Core.Interfaces.IRepositories;

public interface IPostRepository
{
    Task InsertPost(Post post);
    Task<Post?> GetPostById(Guid id);
}