using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Application;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Repositories;
using RecipeBook.Infastracture;
using RecipeBook.Infastracture.Context;
using RecipeBookApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Test.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationModule(Configuration);
            services.AddControllers().AddApplicationPart(typeof(Startup).Assembly);
            services.AddMediatR(typeof(Startup));
            services.AddInfastructreModuleTestDB(Configuration);
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = "Test";
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<RecipeBookDbContext>();

            AddTestData(context);

            base.Configure(app, env);
        }

        private void AddTestData(RecipeBookDbContext context)
        {
            for (int i = 1111; i < 1115; i++)
            {
                Author author = new();
                author.Id = i;
                author.Name = $"Sarp {i}";
                context.Authors.Add(author);
                

                for (int j = 1111; j < 1115; j++)
                {
                    Food food = new();
                    food.AuthorId = i;
                    food.Name = $"Name food {j}";
                    context.Foods.Add(food);
                }

                
            }
            context.SaveChanges();

        }
    }

}