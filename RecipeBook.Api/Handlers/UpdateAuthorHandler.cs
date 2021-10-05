using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeBook.Application.Services;
using RecipeBookApi.Commands;

namespace RecipeBook.Application.Handlers
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand,bool>
    {
        private readonly IAuthorService _authorService;
        
        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return _authorService.UpdateAuthor(request._authorUpdateDto);
        }
    }
}