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

        await tagRepository.InsertTag(tag);
    }

    public async Task<IEnumerable<Tag>> GetAllTags()
    {
        return await tagRepository.GetAllTags();
    }
}