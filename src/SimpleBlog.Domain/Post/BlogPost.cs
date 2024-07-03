using SimpleBlog.Domain.Common;

namespace SimpleBlog.Domain.Post;

public class BlogPost : Entity
{
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;

    private readonly List<Comment> _comments = [];

    public BlogPost(string title, string content)
    {
        SetTitle(title);
        SetContent(content);
    }

    public IReadOnlyCollection<Comment> Comments => _comments;

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void RemoveComment(Comment comment)
    {
        _comments.Remove(comment);
    }

    public void SetTitle(string title)
    {
        Title = title;
    }

    public void SetContent(string content)
    {
        Content = content;
    }
}
