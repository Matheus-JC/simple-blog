namespace SimpleBlog.Domain.Post;

public interface IPostRepository : IDisposable
{
    Task<IEnumerable<BlogPost>> GetAllWithCommentsAsync();
    Task<BlogPost?> GetByIdAsync(Guid id);
    Task<BlogPost?> GetByIdWithCommentsAsync(Guid id);

    void Create(BlogPost post);
    void Create(Comment comment);
}
