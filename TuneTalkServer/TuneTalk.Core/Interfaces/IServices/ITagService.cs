using TuneTalk.Core.Entities;

namespace TuneTalk.Core.Interfaces.IServices;

public interface ITagService
{
    Task CreateTag(string name);
    Task<List<Tag>> GetAllTags();
}