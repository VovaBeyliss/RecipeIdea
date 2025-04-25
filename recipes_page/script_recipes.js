document.addEventListener("DOMContentLoaded", () => {
    let return_to_main_butoon = document.getElementById("main");
    let return_to_creating_butoon = document.getElementById("creating");

    return_to_main_butoon.addEventListener("click", () => {
        location.assign("file:///D:/Programming/VebSites_Projects/ResipeIdea/start_page/index_start.html");
    })

    return_to_creating_butoon.addEventListener("click", () => {
        location.assign("file:///D:/Programming/VebSites_Projects/ResipeIdea/create_page/index_create.html");
    })
})