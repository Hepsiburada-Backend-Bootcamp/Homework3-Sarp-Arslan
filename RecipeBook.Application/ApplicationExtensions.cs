using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Application.Services;

namespace RecipeBook.Application
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IAuthorService, AuthorService>();
        }
    }
}