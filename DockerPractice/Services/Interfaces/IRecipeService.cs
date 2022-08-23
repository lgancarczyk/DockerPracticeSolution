using DockerPractice.Entities;
using DockerPractice.Models;

namespace DockerPractice.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<List<RecipeModel>> GetAll();
        Task<RecipeModel> GetById(int id);
        void AddRecipe(RecipePostModel recipePostModel);
    }
}
