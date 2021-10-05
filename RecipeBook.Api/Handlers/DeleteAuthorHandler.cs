using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeBook.Application.Services;
using RecipeBookApi.Commands;

namespace RecipeBook.Application.Handlers
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand,bool>
    {
        private readonly IAuthorService _authorService;

        public DeleteAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return _authorService.DeleteAuthor(request.Id);
        }
    }
}