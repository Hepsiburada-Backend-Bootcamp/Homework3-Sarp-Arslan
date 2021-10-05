using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Infastracture.Configurations
{
    public class AuthorConfiguration :IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            //builder.HasKey(t => t.Id).HasName("author_id");
            builder.Property(s => s.Name).HasColumnName("name").HasMaxLength(50);
            builder.Property(s => s.Stars).HasColumnName("stars");
        }
    }
}