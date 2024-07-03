namespace SimpleBlog.Application.Post.Dtos;

public class CommentDto
{
    public required Guid BlogPostId { get; set; }
    public required string Content { get; set; }
}
