using System.Threading.Tasks;
using RecipeIdea.Models;
using RecipeIdea.Dtos;

namespace RecipeIdea.Repositories.Interfaces;

public interface IRecipeRepository {
    Task AddRecipeAsync(Recipe request);
    Task<List<Recipe>> GetAllRecipesAsync();
}