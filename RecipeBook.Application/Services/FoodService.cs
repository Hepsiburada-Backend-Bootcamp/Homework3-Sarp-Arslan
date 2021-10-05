using System;
using System.Collections.Generic;
using AutoMapper;
using RecipeBook.Application.DTO.Food;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Repositories;

namespace RecipeBook.Application.Services
{
    public class FoodService :IFoodService
    {
        private readonly IMapper _Mapper;
        private readonly IFoodRepository _FoodRepository;

        public FoodService(IFoodRepository foodRepository, IMapper mapper)
        {
            _Mapper = mapper;
            _FoodRepository = foodRepository;
        }
        public FoodReadDTO GetFood(int id)
        {
            Food food = _FoodRepository.GetById(id);
            return _Mapper.Map<FoodReadDTO>(food);
        }

        public List<FoodReadDTO> GetAllFoods()
        {
            List<FoodReadDTO> foodsDtos = new List<FoodReadDTO>();
            foreach (var food in _FoodRepository.GetAll())
            {
                var convertedData = _Mapper.Map<FoodReadDTO>(food);
                foodsDtos.Add(convertedData);
            }

            return foodsDtos;
        }

        public bool CreateFood(FoodCreateDTO foodCreateDto)
        {
            var food = _Mapper.Map<Food>(foodCreateDto);
            return _FoodRepository.Create(food);
        }

        public bool UpdateFood(FoodUpdateDTO foodUpdateDto)
        {
            var food = _Mapper.Map<Food>(foodUpdateDto);
            return _FoodRepository.Update(food);
        }

        public bool DeleteFood(int id)
        {
            return _FoodRepository.Delete(id);
        }
    }
}