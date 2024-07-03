using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure.Data;

namespace SimpleBlog.Api.Extensions;

public static class DatabaseManagementService
{
    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()?.Database.Migrate();
    }
}
