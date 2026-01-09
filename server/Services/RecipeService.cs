using Microsoft.EntityFrameworkCore;
using RecipeIdea.Services.Interfaces;
using RecipeIdea.Models;
using RecipeIdea.Data;
using RecipeIdea.Dtos;

namespace RecipeIdea.Services.Interfaces;

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
            Ingridients = request.Ingridients,
            PhotoPath = "photo.jpg"
        };

        _db.Recipes.Add(recipe);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Recipe>> GetAllRecipes() {
        var recipes = await _db.Recipes.ToListAsync();

        return recipes;
    }
}