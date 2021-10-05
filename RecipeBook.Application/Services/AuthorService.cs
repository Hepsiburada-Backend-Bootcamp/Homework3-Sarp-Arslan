using System;
using System.Collections.Generic;
using AutoMapper;
using RecipeBook.Application.DTO.Author;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Repositories;

namespace RecipeBook.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _Mapper;
        private readonly IAuthorRepository _AuthorRepository;
        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _Mapper = mapper;
            _AuthorRepository = repository;
        }

        public List<Author> GetAll()
        {
            return _AuthorRepository.GetAll();
        }

        public AuthorReadDTO GetAuthor(int id)
        {
            var author = _AuthorRepository.GetById(id);
            return _Mapper.Map<AuthorReadDTO>(author);
        }

        public bool CreateAuthor(AuthorCreateDTO authorDTO)
        {
            var author = _Mapper.Map<Author>(authorDTO);
            return _AuthorRepository.Create(author);
        }

        public bool UpdateAuthor(AuthorUpdateDTO authorDTO)
        {
            var author = _Mapper.Map<Author>(authorDTO);
            return _AuthorRepository.Update(author);

        }

        public bool DeleteAuthor(int id)
        {
            return _AuthorRepository.Delete(id);
        }
    }
}