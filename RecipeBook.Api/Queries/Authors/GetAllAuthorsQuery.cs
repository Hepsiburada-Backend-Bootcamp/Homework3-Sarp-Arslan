using System.Collections.Generic;
using MediatR;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.Queries.Authors
{

    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {
        
    }
}