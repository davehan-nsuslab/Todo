namespace Todo.Persistence.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Repositories;
using Todo.Persistence.Contexts;
using Todo.Persistence.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ITodoRepository, TodoRepository>()
                // .AddStackExchangeRedisCache(options =>
                //                             {
                //                                 options.Configuration = configuration.GetConnectionString("RedisConnectionString");
                //                             })
                .AddDbContext<TodoDbContext>(options =>
                                                    {
                                                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                                                    });

        return services;
    } 
}
