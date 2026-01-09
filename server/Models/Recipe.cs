namespace RecipeIdea.Models;

public class Recipe {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string TimeCooking { get; set; } = null!;
    public string Ingredients { get; set; } = null!;
    public string Image { get; set; } = null!;
}