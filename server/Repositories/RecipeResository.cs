using Microsoft.EntityFrameworkCore;
using RecipeIdea.Repositories.Interfaces;
using RecipeIdea.Models;
using RecipeIdea.Data;
using RecipeIdea.Dtos;

namespace RecipeIdea.Repositories;

public class RecipeRepository : IRecipeRepository {
    private readonly AppDbContext _db;

    public RecipeRepository(AppDbContext db) {
        _db = db;
    }

    public async Task SaveRecipeAsync(RecipeDto request) {
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

    public async Task<List<Recipe>> GetAllRecipesAsync() => await _db.Recipes.ToListAsync();
}