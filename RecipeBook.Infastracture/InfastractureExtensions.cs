using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Domain.Repositories;
using RecipeBook.Infastracture.Context;
using RecipeBook.Infastracture.Repositories;

namespace RecipeBook.Infastracture
{
    public static class InfastractureExtensions
    {
        public static IServiceCollection AddInfastructreModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RecipeBookDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("Postgres"),
                    x => x.MigrationsAssembly("RecipeBook.Api")));

            services.AddScoped<RecipeBookDbContext>();

            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            return services;
        }

        public static IServiceCollection AddInfastructreModuleTestDB(this IServiceCollection services,
            IConfiguration configuration)
        {
      
            services.AddScoped<RecipeBookDbContext>();
            services.AddDbContext<RecipeBookDbContext>(
                options => options.UseInMemoryDatabase("RecipeBookInMemoryDb"));
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            return services;
        }
    }
}