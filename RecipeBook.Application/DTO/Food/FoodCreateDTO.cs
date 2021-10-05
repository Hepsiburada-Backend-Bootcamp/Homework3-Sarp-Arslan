using System;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.DTO.Food
{
    public class FoodCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public FoodType FoodType { get; set; }
    }
}