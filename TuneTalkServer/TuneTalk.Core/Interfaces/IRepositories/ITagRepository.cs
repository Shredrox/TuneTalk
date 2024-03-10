using TuneTalk.Core.Entities;

namespace TuneTalk.Core.Interfaces.IRepositories;

public interface ITagRepository
{
    Task CreateTag(Tag tag);
    Task<List<Tag>> GetAllTags();
}