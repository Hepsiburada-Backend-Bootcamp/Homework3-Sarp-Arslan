using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeBook.Application.DTO.Author;
using RecipeBook.Application.Queries.Authors;
using RecipeBook.Application.Services;
using RecipeBookApi.Commands;

namespace RecipeBookApi.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;
        private readonly IMediator _mediator;
        
        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger, IMediator mediator)
        {
            _authorService = authorService;
            _logger = logger;
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var query = new GetAllAuthorsQuery();
            var result = await _mediator.Send(query);
            _logger.LogInformation("Get request for all authors");
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var query = new GetAuthorByIdQuery(id);
            var result = await _mediator.Send(query);
            _logger.LogInformation("Get request id for spesific author");
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreateDTO authorDTO)
        {
            _logger.LogInformation("Post request to create author");
            var query = new CreateAuthorCommand(authorDTO);
            var result = await _mediator.Send(query);
            return result != false ? Ok() : BadRequest();
        }
        
        [HttpPatch]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorUpdateDTO authorDTO)
        {
            var query = new UpdateAuthorCommand(authorDTO);
            var result = await _mediator.Send(query);
            _logger.LogInformation("Patch request to author" + authorDTO.Id);
            return result != false ? Ok() : BadRequest();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var query = new DeleteAuthorCommand(id);
            var result = await _mediator.Send(query);
            _logger.LogInformation("Delete request for spesific author " + id);
            return result != false ? Ok() : BadRequest();
        }
    }
}