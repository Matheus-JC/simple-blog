using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.Notifications;
using SimpleBlog.Application.Post;
using SimpleBlog.Application.Post.Dtos;

namespace SimpleBlog.Api.Controllers;

[Route("api/posts")]
public class PostController(IPostService postService, INotifier notifier) : MainController(notifier)
{
    private readonly IPostService _postService = postService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BlogPostDetailsDto>>> GetAllAsync()
    {
        return Ok(await _postService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<BlogPostWithCommentsDto>>> GetByIdWithCommentsAsync(Guid id)
    {
        var blogPostDto = await _postService.GetByIdWithCommentsAsync(id);

        if (blogPostDto is null)
        {
            return NotFound("Blog Post not found");
        }

        return Ok(blogPostDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BlogPostDto>> CreateAsync(BlogPostDto blogPostDto)
    {
        if (!ModelState.IsValid)
        {
            return HandleBadRequest(ModelState);
        }

        var postId = await _postService.CreateAsync(blogPostDto);

        if (IsOperationInvalid())
        {
            return HandleBadRequest();
        }

        return CreatedAtAction("GetByIdWithComments", new { id = postId }, blogPostDto);
    }

    [HttpPost("{id:guid}/comments")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CommentDto>> CreateCommentAsync(Guid id, CommentDto commentDto)
    {
        if (!ModelState.IsValid)
        {
            return HandleBadRequest(ModelState);
        }

        if (commentDto.BlogPostId != id)
        {
            Notify("The blog post id isn't the same as the blog post id of the object");
            return HandleBadRequest();
        }

        await _postService.CreateAsync(commentDto);

        if (IsOperationInvalid())
        {
            return HandleBadRequest();
        }

        return NoContent();
    }
}
