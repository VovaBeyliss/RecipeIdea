using RecipeIdea.Repositories.Interfaces;
using RecipeIdea.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RecipeIdea.Extensions;
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
        await _recipeRepository.SaveRecipeAsync(request);
    }

    public async Task<List<Recipe>> GetAllRecipesAsync() {
        return await _recipeRepository.GetAllRecipesAsync().ReverseAsync();
    }
}