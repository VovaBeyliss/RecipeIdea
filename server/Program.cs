using RecipeIdea.Repositories.Interfaces;
using RecipeIdea.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RecipeIdea.Repositories;
using RecipeIdea.Services;
using RecipeIdea.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAll", policy =>
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());
});

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite("Data Source=RecipeIdea.db");
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapControllers();

using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
    Console.WriteLine("Database created");
}

app.Run();
