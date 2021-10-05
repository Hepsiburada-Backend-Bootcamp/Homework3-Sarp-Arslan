using System.Collections.Generic;
using AutoMapper;
using RecipeBook.Application.DTO.Author;
using RecipeBook.Application.DTO.Food;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.Map
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<FoodUpdateDTO,Food>();
            CreateMap<Food,FoodUpdateDTO>();
            CreateMap<FoodCreateDTO, Food>();
            CreateMap<Food, FoodCreateDTO>();
            CreateMap<Food, FoodReadDTO>();
            CreateMap<FoodReadDTO, Food>();
            
            

            CreateMap<AuthorCreateDTO, Author>();
            CreateMap<Author, AuthorCreateDTO>();
            CreateMap<AuthorUpdateDTO, Author>();
            CreateMap<Author, AuthorUpdateDTO>();
            CreateMap<Author, AuthorReadDTO>();
            CreateMap<AuthorReadDTO, Author>();
        }
    }
}