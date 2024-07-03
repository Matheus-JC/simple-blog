using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Domain.Common;
using SimpleBlog.Domain.Post;
using SimpleBlog.Infrastructure.Data;
using SimpleBlog.Infrastructure.Data.Repositories;
using SimpleBlog.Infrastructure.Data.UnitOfWork;

namespace SimpleBlog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPostRepository, PostRepository>();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
        return services;
    }
}
