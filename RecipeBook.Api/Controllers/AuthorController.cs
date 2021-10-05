using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeBook.Application.DTO.Author;
using RecipeBook.Application.Services;

namespace RecipeBookApi.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;
        
        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;

        }
        
        [HttpGet]
        public IActionResult GetAuthors()
        {
            _logger.LogInformation("Get request for all authors");
            return Ok(_authorService.GetAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            _logger.LogInformation("Get request id for spesific author");
            return Ok(_authorService.GetAuthor(id));
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorCreateDTO authorDTO)
        {
            _logger.LogInformation("Post request to create author");
            return Ok(_authorService.CreateAuthor(authorDTO));
        }
        
        [HttpPatch]
        public IActionResult UpdateAuthor([FromBody] AuthorUpdateDTO authorDTO)
        {
            _logger.LogInformation("Patch request to author" + authorDTO.Id);
            return Ok(_authorService.UpdateAuthor(authorDTO));
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _logger.LogInformation("Delete request for spesific author " + id);
            return Ok(_authorService.DeleteAuthor(id));
        }
    }
}