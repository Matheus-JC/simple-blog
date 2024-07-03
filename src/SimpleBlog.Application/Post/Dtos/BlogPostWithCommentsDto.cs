namespace SimpleBlog.Application.Post.Dtos;

public class BlogPostWithCommentsDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public List<CommentContentDto> Comments { get; set; } = [];
}
