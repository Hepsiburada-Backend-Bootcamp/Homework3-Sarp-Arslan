using Moq;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecipeBook.Test.UnitTests.AuthorRepositoryTest
{
    public class FoodRepositoryTest
    {
        List<Food> foods = new List<Food>();


        public FoodRepositoryTest()
        {
            addFood();
        }

        public void addFood()
        {
            for (int i = 1; i < 10; i++)
            {
                foods.Add(new Food(i));
            }
        }

        [Fact]
        public void getAll_Return_Food_list()
        {
            Mock<IFoodRepository> mockFoodRepository = new Mock<IFoodRepository>();

            mockFoodRepository.Setup(fr => fr.GetAll()).Returns(() => foods);

            var foodRepository = mockFoodRepository.Object;
            var foodsFromDB = foodRepository.GetAll();

            Assert.Equal(foods.Count, foodsFromDB.Count);
        }


        [Fact]
        public  void GetByGivenId_Should_Return_Food()
        {
            //Arrange
            Mock<IFoodRepository> mockFoodRepository = new Mock<IFoodRepository>();

            mockFoodRepository.Setup(fr => fr.GetById(It.IsAny<int>())).Returns(new Food(1));
            IFoodRepository foodRepository = mockFoodRepository.Object;

            //Act
            var result = (foodRepository.GetById(1));

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Remove_Food()
        {
            //Arrange
            Mock<IFoodRepository> mockAuthorRepository = new Mock<IFoodRepository>();
            var foodCount = foods.Count;
            mockAuthorRepository.Setup(fr => fr.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var food = foods.FirstOrDefault(x => x.Id == id);
                foods.Remove(food);
            });

            //Act
            var authorRepository = mockAuthorRepository.Object;
            authorRepository.Delete(1);

            //Assert
            Assert.True(foodCount > foods.Count);
            Assert.Null(foods.FirstOrDefault(x => x.Id == 1));
        }
    }
}
