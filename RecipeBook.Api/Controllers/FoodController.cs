using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.DTO.Food;
using RecipeBook.Application.Services;

namespace RecipeBookApi.Controllers
{
    [ApiController]
    [Route("api/v1/foods")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodservice;
        public FoodController(IFoodService foodservice)
        {
            _foodservice = foodservice;
        }
        // GET
        [HttpGet]
        public IActionResult GetFoodList()
        {
            return Ok(_foodservice.GetAllFoods());
        }
        
        [HttpGet ("id")]
        public IActionResult GetFoodById(int id)
        {
            return Ok(_foodservice.GetFood(id));
        }
        
        [HttpPost]
        public IActionResult AddFood(FoodCreateDTO foodCreateDto)
        {
            return Ok(_foodservice.CreateFood(foodCreateDto));
        }
        
        [HttpPatch]
        public IActionResult UpdateFood(FoodUpdateDTO foodUpdateDto)
        {
            return Ok(_foodservice.UpdateFood(foodUpdateDto));
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteFood(int id)
        {
            return Ok(_foodservice.DeleteFood(id));
        }
        
    }
}