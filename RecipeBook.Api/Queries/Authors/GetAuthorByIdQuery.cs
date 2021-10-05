using System.Collections.Generic;
using MediatR;
using RecipeBook.Application.DTO.Author;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.Queries.Authors
{
    public class GetAuthorByIdQuery : IRequest<AuthorReadDTO>
    {
        public int Id { get; }

        public GetAuthorByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}