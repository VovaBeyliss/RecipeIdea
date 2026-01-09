namespace RecipeIdea.Models;

public class Recipe {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string TimeCooking { get; set; } = null!;
    public string Ingridients { get; set; } = null!;
    public string PhotoPath { get; set; } = null!;
}