using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Repositories;
using RecipeBook.Infastracture.Context;

namespace RecipeBook.Infastracture.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RecipeBookDbContext _postgresDbContext;
        public AuthorRepository(RecipeBookDbContext dbContext)
        {
            _postgresDbContext = dbContext;
        }
        public List<Author> GetAll()
        {
            /*return _postgresDbContext.Authors.Select(author => new Author()
            {
                Foods = _postgresDbContext.Foods.Where( food => food.Author.Id == author.Id).ToList(),
            }).ToList();*/
            return _postgresDbContext.Authors.ToList();
        }

        public List<Author> GetAll(string filter)
        {
            return null; // TODO 
        }

        public Author GetById(int id)
        {
            return _postgresDbContext.Authors.FirstOrDefault(author => author.Id == id);
        }

        public bool Create(Author author)
        {
             var addAuthor  = _postgresDbContext.Authors.Add(author);
             if (addAuthor == null)
                 return false;
             _postgresDbContext.SaveChanges();
             return true;
        }

        public bool Update(Author author)
        {
            var updateAuthor = _postgresDbContext.Authors.Update(author);
            if (updateAuthor == null)
                return false;
            _postgresDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var author = _postgresDbContext.Authors.FirstOrDefault(author => author.Id == id);
            if (author == null)
                return false;
            _postgresDbContext.Authors.Remove(author);
            _postgresDbContext.SaveChanges();
            return true;
        }
    }
}