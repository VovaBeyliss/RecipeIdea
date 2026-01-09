document.addEventListener("DOMContentLoaded", () => {
    let nav_button = document.getElementById("nav");
    let image = document.querySelector(".menu-img");

    nav_button.addEventListener("click", () => {
        image.scrollIntoView({behavior: "smooth"});
    })

    let about = document.getElementById("info");
    let info = document.querySelector(".orin");

    about.addEventListener("click", () => {
        info.scrollIntoView({behavior: "smooth"});
    })

    let create_nav = document.getElementById("recipe");
    let button_create = document.querySelector(".button-recipe1");
    let button_recipes = document.querySelector(".button-recipe2");

    create_nav.addEventListener("click", () => {
        button_create.scrollIntoView({behavior: "smooth"});
    })

    button_create.addEventListener("click", () => {
        location.href = "index_create.html";
    })

    button_recipes.addEventListener("click", () => {
        location.href = "index_recipes.html";
    })
})