using FluentValidation;
using SimpleBlog.Application.Post.Dtos;

namespace SimpleBlog.Application.Post.Validators;

public class BlogPostDtoValidator : AbstractValidator<BlogPostDto>
{
    public BlogPostDtoValidator()
    {
        RuleFor(bp => bp.Title)
            .NotEmpty()
            .Length(2, 100);

        RuleFor(bp => bp.Content)
            .NotEmpty()
            .Length(2, 1000);
    }
}
