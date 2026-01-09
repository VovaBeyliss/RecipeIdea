using Microsoft.EntityFrameworkCore;
using RecipeIdea.Models;
using RecipeIdea.Dtos;

namespace RecipeIdea.Services.Interfaces;

public interface IRecipeService {
    Task SaveRecipe(RecipeDto request);
    Task<List<Recipe>> GetAllRecipes();
}