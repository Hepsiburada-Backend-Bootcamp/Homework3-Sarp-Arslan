using System;
using System.Collections.Generic;
using System.Linq;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Repositories;
using RecipeBook.Infastracture.Context;

namespace RecipeBook.Infastracture.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly RecipeBookDbContext _postgresDbContext;
        public FoodRepository(RecipeBookDbContext dbContext)
        {
            _postgresDbContext = dbContext;
        }
        
        public List<Food> GetAll()
        {
            return _postgresDbContext.Foods.ToList();
        }

        public List<Food> GetAll(string filter)
        {
            return null; // TODO
        }

        public Food GetById(int id)
        {
            return _postgresDbContext.Foods.FirstOrDefault(food => food.Id == id);
        }

        public bool Create(Food food)
        {
            var addedFood = _postgresDbContext.Foods.Add(food);
            if (addedFood == null)
                return false;
            _postgresDbContext.SaveChanges();
            return true;
        }

        public bool Update(Food food)
        {
            var updatedFood =_postgresDbContext.Foods.Update(food);
            if (updatedFood == null)
                return false;
            _postgresDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var food = _postgresDbContext.Foods.FirstOrDefault(food => food.Id == id);
            if (food == null)
                return false;
            _postgresDbContext.Foods.Remove(food);
            return true;
        }
    }
}