using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Infastracture
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
            {
            /*
                modelBuilder.Entity<Author>().HasData(
                    new Author { Id = 1, Name = "Sarp", Surname = "Arslan" ,Age = 25,Stars = 5},
                    new Author { Id = 2, Name = "Mike", Surname = "Corc" , Age = 22,Stars = 5},
                    new Author { Id = 3, Name = "Dummy", Surname = "Dumm" ,Age = 19, Stars = 6}
                );
               
                modelBuilder.Entity<Food>().HasData(
                    new Food { Id = 1, AuthorId = 1, Name = "Menemen" },
                    new Food { Id = 2, AuthorId = 1, Name = "Tost" },
                    new Food { Id = 3, AuthorId = 1, Name = "Kebap" },
                    new Food { Id = 4, AuthorId = 2, Name = "Dumm" },
                    new Food { Id = 5, AuthorId = 2, Name = "DumHamburger",},
                    new Food { Id = 6, AuthorId = 3, Name = "Kebap" }
                ); */
            }
        }
}
