using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeIdea.Services.Interfaces;
using RecipeIdea.Services;
using RecipeIdea.Dtos;

[ApiController]
[Route("api/recipe")]
public class RecipeController : ControllerBase {
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService) {
        _recipeService = recipeService;
    }

    [HttpPost]
    public async Task<IActionResult> SaveRecipe([FromBody] RecipeDto request) {
        await _recipeService.SaveRecipe(request);

        return Ok(new { success = true });
    }

    [HttpGet]
    public async Task<IActionResult> ReturnAllRecipes() {
        var recipesList = await _recipeService.GetAllRecipes();

        return Ok(new { success = true, recipes = recipesList });
    }
}