using MediatR;

namespace RecipeBookApi.Commands
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteAuthorCommand(int ıd)
        {
            Id = ıd;
        }
    }
}