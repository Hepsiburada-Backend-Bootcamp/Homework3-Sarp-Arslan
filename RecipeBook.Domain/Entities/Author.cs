using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Stars { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}