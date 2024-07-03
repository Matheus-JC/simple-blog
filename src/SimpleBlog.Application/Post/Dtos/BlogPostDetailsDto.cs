namespace SimpleBlog.Application.Post.Dtos;

public class BlogPostDetailsDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public int CommentsCount { get; set; }
}
