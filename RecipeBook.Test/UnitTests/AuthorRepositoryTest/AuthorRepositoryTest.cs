using Moq;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RecipeBook.Test.UnitTests.AuthorRepositoryTest
{
    public class AuthorRepositoryTest
    {
        List<Author> authors = new List<Author>();

        public AuthorRepositoryTest()
        {
            addAuthors();
        }

        public void addAuthors()
        {
            for (int i = 1; i < 10; i++)
            {
                authors.Add(new Author(i));
            }
        }

        [Fact]
        public void getAll_Return_Author_list()
        {
            Mock<IAuthorRepository> mockAuthorRepository = new Mock<IAuthorRepository>();

            mockAuthorRepository.Setup(ar => ar.GetAll()).Returns(() => authors);

            var authorRepository = mockAuthorRepository.Object;
            var authorsFromDB = authorRepository.GetAll();

            Assert.Equal(authors.Count, authorsFromDB.Count);
        }

        [Fact]
        public async void GetByGivenId_Should_Return_Author()
        {
            //Arrange
            Mock<IAuthorRepository> mockAuthorRepository = new Mock<IAuthorRepository>();

            mockAuthorRepository.Setup(ar => ar.GetById(It.IsAny<int>())).Returns(new Author(1));
            IAuthorRepository authorRepository = mockAuthorRepository.Object;

            //Act
            var result = (authorRepository.GetById(1));

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Remove_Author()
        {
            //Arrange
            Mock<IAuthorRepository> mockAuthorRepository = new Mock<IAuthorRepository>();
            var authorCount = authors.Count;
            mockAuthorRepository.Setup(ar => ar.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var author = authors.FirstOrDefault(x => x.Id == id);
                authors.Remove(author);
            });

            //Act
            var authorRepository = mockAuthorRepository.Object;
            authorRepository.Delete(1);

            //Assert
            Assert.True(authorCount > authors.Count);
            Assert.Null(authors.FirstOrDefault(x => x.Id == 1));
        }

    }
}