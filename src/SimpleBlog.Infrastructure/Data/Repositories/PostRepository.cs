using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Post;

namespace SimpleBlog.Infrastructure.Data.Repositories;

public class PostRepository(ApplicationDbContext context) : IPostRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<BlogPost>> GetAllWithCommentsAsync()
    {
        return await _context.BlogPosts
            .Include(bp => bp.Comments)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        return await _context.BlogPosts.FindAsync(id);
    }

    public async Task<BlogPost?> GetByIdWithCommentsAsync(Guid id)
    {
        return await _context.BlogPosts
            .Include(bp => bp.Comments)
            .FirstOrDefaultAsync(bp => bp.Id == id);
    }

    public void Create(BlogPost post)
    {
        _context.BlogPosts.Add(post);
    }

    public void Create(Comment comment)
    {
        _context.Comments.Add(comment);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
