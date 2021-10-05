using System;
using System.Collections.Generic;
using RecipeBook.Application.DTO.Author;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.Services
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        AuthorReadDTO GetAuthor(int id);
        bool CreateAuthor(AuthorCreateDTO authorDTO);

        bool UpdateAuthor(AuthorUpdateDTO authorDTO);

        bool DeleteAuthor(int id);
    }
}