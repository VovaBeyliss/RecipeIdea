using System.Threading.Tasks;
using RecipeIdea.Models;
using RecipeIdea.Dtos;

namespace RecipeIdea.Repositories.Interfaces;

public interface IRecipeRepository {
    Task SaveRecipeAsync(RecipeDto request);
    Task<List<Recipe>> GetAllRecipesAsync();
}