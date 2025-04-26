document.addEventListener("DOMContentLoaded", () => {
    let name = document.getElementById("name");
    let description = document.getElementById("description");
    let time_cooking = document.getElementById("time-cooking");
    let ingridients = document.getElementById("ingridients");
    
    let arrayRecipe = [name, description, time_cooking, ingridients];

    document.querySelector(".create-button").addEventListener("click", async () => {
        let all_filled = true;

        for (let i = 0; i < arrayRecipe.length; i++) {
            if (arrayRecipe[i].value == "") {
                arrayRecipe[i].style.border = "2px solid red";
                arrayRecipe[i].style.boxShadow = "0 0 30px red";
                all_filled = false;
            } else {
                arrayRecipe[i].style.border = "2px solid white";
                arrayRecipe[i].style.boxShadow = "none";
            }
        }

        if (all_filled) {
            try {
                const response = await fetch('http://localhost:3000/api/save', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        name: name.value,
                        description: description.value,
                        timeCooking: time_cooking.value,
                        ingridients: ingridients.value
                    })
                });
                
                const data = await response.json();
                
                if (!response.ok) {
                    throw new Error(data.error || "Помилка сервера");
                }
                
                if (data.success) {
                    location.assign("file:///C:/Users/Admin/RecipeIdea/public/recipes_page/index_recipes.html");
                } else {
                    alert("Помилка при збереженні: " + (data.message || ""));
                }
            } catch (error) {
                console.error('Помилка:', error);
                alert("Помилка з'єднання: " + error.message);
            }
        }
    })

    document.getElementById("creating").addEventListener("click", () => {
        document.getElementById("h-5").scrollIntoView({behavior: "smooth"});
    })

    document.getElementById("save").addEventListener("click", () => {
        document.querySelector(".create-button").scrollIntoView({behavior: "smooth"});
    })
})