using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Infastracture.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            //builder.HasKey(s => s.Id).HasName("food_id");
            builder.Property(s => s.FoodType).HasColumnName("food_type");
        }
    }
}