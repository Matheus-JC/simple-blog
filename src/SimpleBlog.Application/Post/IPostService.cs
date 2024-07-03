using SimpleBlog.Application.Post.Dtos;

namespace SimpleBlog.Application.Post;

public interface IPostService : IDisposable
{
    Task<IEnumerable<BlogPostDetailsDto>> GetAllAsync();
    Task<BlogPostDto?> GetByIdAsync(Guid id);
    Task<BlogPostWithCommentsDto?> GetByIdWithCommentsAsync(Guid id);

    Task<Guid> CreateAsync(BlogPostDto blogPostDto);
    Task CreateAsync(CommentDto commentDto);
}
