using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Application.Notifications;
using SimpleBlog.Application.Post;

namespace SimpleBlog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<INotifier, Notifier>();
        services.AddScoped<IPostService, PostService>();

        services.AddAutoMapper(typeof(PostMappingProfile).Assembly);

        return services;
    }
}
