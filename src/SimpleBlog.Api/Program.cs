using SimpleBlog.Api.Extensions;
using SimpleBlog.Application;
using SimpleBlog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationDependencies()
    .AddInfrastructureDependencies(builder.Configuration);

var app = builder.Build();


if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    DatabaseManagementService.MigrationInitialisation(app);
}
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();

