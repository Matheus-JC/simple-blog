using AutoMapper;
using SimpleBlog.Application.Post.Dtos;
using SimpleBlog.Domain.Post;

namespace SimpleBlog.Application.Post;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<BlogPost, BlogPostDto>().ReverseMap();
        CreateMap<BlogPost, BlogPostWithCommentsDto>();
        CreateMap<BlogPost, BlogPostDetailsDto>().ForMember(dest => dest.CommentsCount, 
            opt => opt.MapFrom(src => src.Comments.Count));

        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Comment, CommentContentDto>();
    }
}
