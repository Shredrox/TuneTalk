using TuneTalk.Core.Entities;
using TuneTalk.Core.Interfaces.IRepositories;
using TuneTalk.Infrastructure.Data;

namespace TuneTalk.Infrastructure.Repositories;

public class PostRepository(TuneTalkDbContext context) : IPostRepository
{
    public async Task InsertPost(Post post)
    {
        context.Posts.Add(post);
        await context.SaveChangesAsync();
    }

    public async Task<Post?> GetPostById(Guid id)
    {
        return await context.Posts.FindAsync(id);
    }
}