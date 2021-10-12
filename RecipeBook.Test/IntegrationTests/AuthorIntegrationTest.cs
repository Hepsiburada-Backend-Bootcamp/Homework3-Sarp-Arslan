using Microsoft.AspNetCore.Mvc.Testing;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using RecipeBook.Application;
using RecipeBook.Application.DTO.Author;

namespace RecipeBook.Test.IntegrationTests
{
    public class AuthorIntegrationTest : IClassFixture<RecipeBookApiFactory>
    {
        private readonly WebApplicationFactory<TestStartup> _factory;

        public AuthorIntegrationTest(RecipeBookApiFactory factory)
        {
            _factory = factory;
        }


        [Fact]
        public async void Post_To_Create_Should_Return_Ok()
        {
            var author = new AuthorCreateDTO
            {
                Id = 22222,
                Name = "Sarp",
                Age = 99,
                Stars = 5,
                Surname = "Arslan"
            };

            var json = JsonSerializer.Serialize(author);

            var client = _factory.CreateClient();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var postResponse = await client.PostAsync("api/v1/authors", content);

            var actualStatusCode = postResponse.StatusCode;

            Assert.Equal(HttpStatusCode.OK, actualStatusCode);

        }

        [Fact]
        public async void  Delete_Return_NotFound_When_AuthorIsNotFound()
        {
            //Arrange

            var client = _factory.CreateClient();

            //Act
      
            var responseDelete = await client.DeleteAsync($"api/v1/authors/11234");
            var actualStatusCode = responseDelete.StatusCode;

            //Assert

            Assert.Equal(HttpStatusCode.NotFound, actualStatusCode);

        }

        [Fact]
        public async void GetById_Should_ReturnBad_Request_If_Id_Not_Found()
        {
            //Arrange

            var client = _factory.CreateClient();

            //Act

            var responseDelete = await client.GetAsync($"api/v1/authors/11234");
            var actualStatusCode = responseDelete.StatusCode;

            //Assert

            Assert.Equal(HttpStatusCode.NotFound, actualStatusCode);

        }

    }
}
