using SimpleBlog.Domain.Common;

namespace SimpleBlog.Domain.Post;

public class Comment : Entity
{
    public Guid BlogPostId { get; private set; }
    public string Content { get; private set; } = null!;

    public Comment(Guid blogPostId, string content)
    {
        SetBlogPostId(blogPostId);
        SetContent(content);
    }

    public void SetBlogPostId(Guid blogPostId)
    {
        BlogPostId = blogPostId;
    }

    public void SetContent(string content)
    {
        Content = content;
    }
}