using System;
using System.Collections.Generic;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Repositories
{
    public interface IFoodRepository
    {
        List<Food> GetAll();
        List<Food> GetAll(string filter);
        Food GetById(int id);
        bool Create(Food food);
        bool Update(Food food);
        bool Delete(int id);
    }
}