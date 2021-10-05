using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.DTO.Food
{
    public class FoodUpdateDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public FoodType FoodType { get; set; }
        
    }
}