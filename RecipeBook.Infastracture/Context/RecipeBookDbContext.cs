using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Infastracture.Context
{
    public class RecipeBookDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Author> Authors { get; set; }
        public RecipeBookDbContext(DbContextOptions<RecipeBookDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeBookDbContext).Assembly);
            modelBuilder.Seed();
        }
        
        
    }
}