using MediatR;
using RecipeBook.Application.DTO.Author;

namespace RecipeBookApi.Commands
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public AuthorUpdateDTO _authorUpdateDto { get; }

        public UpdateAuthorCommand(AuthorUpdateDTO authorUpdateDto)
        {
            _authorUpdateDto = authorUpdateDto;
        }
        
    }
}