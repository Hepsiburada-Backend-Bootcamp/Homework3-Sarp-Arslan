using MediatR;
using RecipeBook.Application.DTO.Author;

namespace RecipeBookApi.Commands
{
    public class CreateAuthorCommand : IRequest<bool>
    {
        public AuthorCreateDTO _authorCreateDto { get; }

        public CreateAuthorCommand(AuthorCreateDTO authorCreateDto)
        {
            _authorCreateDto = authorCreateDto;
        }
    }
}