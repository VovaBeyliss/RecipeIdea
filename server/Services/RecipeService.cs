using RecipeIdea.Repositories.Interfaces;
using RecipeIdea.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RecipeIdea.Models;
using RecipeIdea.Data;
using RecipeIdea.Dtos;

namespace RecipeIdea.Services;

public class RecipeService : IRecipeService {
    private readonly IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository) {
        _recipeRepository = recipeRepository;
    }

    public async Task SaveRecipeAsync(RecipeDto request) {
        var recipe = new Recipe {
            Name = request.Name,
            Description = request.Description,
            TimeCooking = request.TimeCooking,
            Ingredients = request.Ingredients,
            Image = request.Image
        };

        await _recipeRepository.AddRecipeAsync(recipe);
    }

    public async Task<List<Recipe>> GetAllRecipesAsync() {
        var recipes = await _recipeRepository.GetAllRecipesAsync();

        recipes.Reverse();

        return recipes;
    }
}