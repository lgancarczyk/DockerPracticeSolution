using DockerPractice.Entities;
using DockerPractice.Models;
using DockerPractice.Services.Interfaces;

namespace DockerPractice.Services
{
    public class RecipeService : IRecipeService
    {
        private AppDBContext _dbContext;

        public RecipeService( AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public void AddRecipe(RecipePostModel recipePostModel)
        {
            var recipe = new RecipeModel() 
            {
                Title = recipePostModel.Title,
                Description = recipePostModel.Description,
            };
            _dbContext.RecipeModels.Add(recipe);
            _dbContext.SaveChanges();
        }

        public async Task<List<RecipeModel>> GetAll()
        {
            return _dbContext.RecipeModels.ToList();
        }

        public async Task<RecipeModel> GetById(int id)
        {
            return _dbContext.RecipeModels.Single(x => x.Id == id);
        }


    }
}
