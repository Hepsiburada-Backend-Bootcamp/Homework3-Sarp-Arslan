using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeBook.Application.Services;
using RecipeBookApi.Commands;

namespace RecipeBook.Application.Handlers
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand,bool>
    {
        private readonly IAuthorService _authorService;

        public CreateAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        { 
            return _authorService.CreateAuthor(request._authorCreateDto);
        }
    }
}