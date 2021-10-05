using System;
using System.Collections.Generic;

namespace RecipeBook.Application.DTO.Author
{
    public class AuthorCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Stars { get; set; }

    }
}