using Microsoft.EntityFrameworkCore;
using RecipeIdea.Models;

namespace RecipeIdea.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Recipe> Recipes { get; set; } = null!;
}