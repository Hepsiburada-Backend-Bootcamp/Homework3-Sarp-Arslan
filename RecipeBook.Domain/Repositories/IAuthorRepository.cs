using System;
using System.Collections.Generic;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        List<Author> GetAll(string filter);
        Author GetById(int id);
        bool Create(Author author);
        bool Update(Author author);
        bool Delete(int id);
    }
}