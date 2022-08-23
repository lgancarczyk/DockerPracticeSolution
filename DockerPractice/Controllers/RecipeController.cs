using DockerPractice.Entities;
using DockerPractice.Models;
using DockerPractice.Services;
using DockerPractice.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerPractice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private IRecipeService recipeService;
        public RecipeController(RecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipeModel>>> GetAllRecipes()
        {
            return Ok(await recipeService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RecipeModel>> GetById(int id)
        {
            return Ok(await recipeService.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult<RecipeModel>> TestGet()
        {
            return Ok("Working");
        }

        [HttpPost]
        public async Task<ActionResult<RecipeModel>> AddRecipe(RecipePostModel recipePostModel)
        {
            recipeService.AddRecipe(recipePostModel);
            return Ok();
        }





    }
}
