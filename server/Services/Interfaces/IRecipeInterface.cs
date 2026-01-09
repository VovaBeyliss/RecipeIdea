using RecipeIdea.Dtos;

namespace RecipeIdea.Services.Interfaces;

interface IRecipeService {
    Task SaveRecipe(RecipeDto request);
    Task<List<Recipe>> GetAllRecipes();
}