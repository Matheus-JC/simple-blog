using FluentValidation;
using SimpleBlog.Application.Post.Dtos;

namespace SimpleBlog.Application.Post.Validators;

public class CommentDtoValidator : AbstractValidator<CommentDto>
{
    public CommentDtoValidator()
    {
        RuleFor(s => s.BlogPostId)
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(c => c.Content)
           .NotEmpty()
           .Length(2, 500);
    }
}
