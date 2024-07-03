using AutoMapper;
using SimpleBlog.Application.Notifications;
using SimpleBlog.Application.Post.Dtos;
using SimpleBlog.Application.Post.Validators;
using SimpleBlog.Domain.Common;
using SimpleBlog.Domain.Post;

namespace SimpleBlog.Application.Post;

public class PostService(IPostRepository postRepository,IUnitOfWork unitOfWork, INotifier notifier, IMapper mapper) 
    : BaseService(unitOfWork, notifier, mapper), IPostService
{
    private readonly IPostRepository _postRepository = postRepository;

    public async Task<IEnumerable<BlogPostDetailsDto>> GetAllAsync()
    {
        var blogPosts = await _postRepository.GetAllWithCommentsAsync();
        return _mapper.Map<IEnumerable<BlogPostDetailsDto>>(blogPosts);
    }

    public async Task<BlogPostDto?> GetByIdAsync(Guid id)
    {
        var blogPosts = await _postRepository.GetByIdAsync(id);
        return _mapper.Map<BlogPostDto>(blogPosts);
    }

    public async Task<BlogPostWithCommentsDto?> GetByIdWithCommentsAsync(Guid id)
    {
        var blogPosts = await _postRepository.GetByIdWithCommentsAsync(id);
        return _mapper.Map<BlogPostWithCommentsDto>(blogPosts);
    }

    public async Task<Guid> CreateAsync(BlogPostDto blogPostDto)
    {
        if(!await Validate(new BlogPostDtoValidator(), blogPostDto))
        {
            return Guid.Empty;
        }

        var blogPost = _mapper.Map<BlogPost>(blogPostDto);

        _postRepository.Create(blogPost);

        await CommitAsync();

        return blogPost.Id;
    }

    public async Task CreateAsync(CommentDto commentDto)
    {
        if (!await Validate(new CommentDtoValidator(), commentDto))
        {
            return;
        }

        var blogPost = await _postRepository.GetByIdAsync(commentDto.BlogPostId);

        if(blogPost is null)
        {
            Notify("The Blog Post informed doesn't exist");
            return;
        }

        var comment = _mapper.Map<Comment>(commentDto);

        _postRepository.Create(comment);

        await CommitAsync();
    }

    public void Dispose()
    {
        _postRepository.Dispose();
        GC.SuppressFinalize(this);
    }
}
