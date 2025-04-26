document.addEventListener("DOMContentLoaded", () => {
    let recipesContainer = document.querySelector(".recipes");
    let margin_top = 200;

    async function fetchAllRecipes() {
        try {
            let response = await fetch('http://localhost:3000/api/all');
            if (!response.ok) {
                throw new Error(`HTTP помилка! Статус: ${response.status}`);
            }
            return await response.json();
        } catch (error) {
            console.error('Помилка при отриманні рецептів:', error);
            let errorDiv = document.createElement("div");
            errorDiv.style.color = "red";
            errorDiv.style.marginTop = `${margin_top}px`;
            errorDiv.textContent = "Не вдалося завантажити рецепти. Спробуйте оновити сторінку.";
            recipesContainer.appendChild(errorDiv);
            return [];
        }
    }

    async function displayRecipes() {
        let recipes = await fetchAllRecipes();

        recipes.forEach(recipe => {
            let recipeDiv = document.createElement("div");
            recipeDiv.className = "recipe";
            recipeDiv.innerHTML = `
                <img id="image" src="images_recipes/logo.png">
                <div class="recipe-info">
                    <p id="name">${recipe.name}</p>
                    <p id="description">${recipe.description}</p>
                    <p id="timeCooking">${recipe.timeCooking}</p>
                    <p id="ingridients">${recipe.ingridients}</p>
                </div>
            `;
            
            recipeDiv.style.marginTop = `${margin_top}px`;
            recipesContainer.appendChild(recipeDiv);
        })
    }

    displayRecipes();
})