using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.DTO.Food
{
    public class FoodReadDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public FoodType FoodType { get; set; }
        public int AuthorId { get; set; } 
    }
}