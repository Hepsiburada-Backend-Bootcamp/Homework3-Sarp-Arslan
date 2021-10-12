using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBook.Domain.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public FoodType FoodType { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public Food(int Id)
        {
            this.Id = Id;
        }

        public Food()
        {
        }
    }
}