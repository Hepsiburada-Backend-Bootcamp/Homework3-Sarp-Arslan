using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeBook.Application.Queries.Authors;
using RecipeBook.Application.Services;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.Handlers
{
    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IAuthorService _authorService;

        public GetAllAuthorsHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        
        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return _authorService.GetAll();
        }
    }
}