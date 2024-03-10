using Microsoft.EntityFrameworkCore;
using TuneTalk.Core.Entities;
using TuneTalk.Core.Interfaces.IRepositories;
using TuneTalk.Infrastructure.Data;

namespace TuneTalk.Infrastructure.Repositories;

public class TagRepository(TuneTalkDbContext context) : ITagRepository
{
    public async Task CreateTag(Tag tag)
    {
        context.Tags.Add(tag);
        await context.SaveChangesAsync();
    }

    public async Task<List<Tag>> GetAllTags()
    {
        return await context.Tags.ToListAsync();
    }
}