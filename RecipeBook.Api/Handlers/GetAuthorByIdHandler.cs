using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeBook.Application.DTO.Author;
using RecipeBook.Application.Queries.Authors;
using RecipeBook.Application.Services;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.Handlers
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, AuthorReadDTO>
    {
        private readonly IAuthorService _authorService;
        
        public GetAuthorByIdHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<AuthorReadDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return _authorService.GetAuthor(request.Id);
        }
    }
}