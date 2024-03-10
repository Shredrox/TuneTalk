using TuneTalk.Core.Entities;
using TuneTalk.Core.Interfaces.IRepositories;
using TuneTalk.Core.Interfaces.IServices;

namespace TuneTalk.Core.Services;

public class TagService(ITagRepository tagRepository) : ITagService
{
    public async Task CreateTag(string name)
    {
        var tag = new Tag
        {
            Name = name
        };

        await tagRepository.CreateTag(tag);
    }

    public async Task<List<Tag>> GetAllTags()
    {
        return await tagRepository.GetAllTags();
    }
}