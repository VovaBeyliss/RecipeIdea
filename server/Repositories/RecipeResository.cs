using RecipeIdea.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using RecipeIdea.Models;
using RecipeIdea.Data;

namespace RecipeIdea.Repositories;

public class RecipeRepository : IRecipeRepository {
    private readonly AppDbContext _db;

    public RecipeRepository(AppDbContext db) {
        _db = db;
    }

    public async Task AddRecipeAsync(Recipe recipe) {
        await _db.Recipes.AddAsync(recipe);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Recipe>> GetAllRecipesAsync() => await _db.Recipes.ToListAsync();
}