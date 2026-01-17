using Microsoft.EntityFrameworkCore;
using RecipeIdea.Services.Interfaces;
using RecipeIdea.Models;
using RecipeIdea.Data;
using RecipeIdea.Dtos;

namespace RecipeIdea.Services;

public class RecipeService : IRecipeService {
    private readonly AppDbContext _db;

    public RecipeService(AppDbContext db) {
        _db = db;
    }

    public async Task SaveRecipe(RecipeDto request) {
        var recipe = new Recipe {
            Name = request.Name,
            Description = request.Description,
            TimeCooking = request.TimeCooking,
            Ingredients = request.Ingredients,
            Image = request.Image
        };

        _db.Recipes.Add(recipe);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Recipe>> GetAllRecipes() => await _db.Recipes.ToListAsync();
}