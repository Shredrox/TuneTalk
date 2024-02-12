namespace TuneTalk.Core.Entities;

public class Post
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public List<Tag> Tags { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}