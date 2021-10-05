using System;
using System.Collections.Generic;
using RecipeBook.Application.DTO.Food;

namespace RecipeBook.Application.Services
{
    public interface IFoodService
    {
        FoodReadDTO GetFood(int id);
        List<FoodReadDTO> GetAllFoods();

        bool CreateFood(FoodCreateDTO foodCreateDto);

        bool UpdateFood(FoodUpdateDTO foodUpdateDto);
        bool DeleteFood(int id);
    }
}