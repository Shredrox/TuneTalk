using TuneTalk.Core.Entities;

namespace TuneTalk.Core.Interfaces.IRepositories;

public interface ITagRepository
{
    Task InsertTag(Tag tag);
    Task<IEnumerable<Tag>> GetAllTags();
}