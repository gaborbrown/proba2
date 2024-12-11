fetch("api/mozi").then(r => r.json()).then(data => {

    const div = document.getElementById("filmek")

    data.forEach(movie => {
        const ujdiv = document.createElement("div")
        ujdiv.className = "ujdiv"
        ujdiv.innerHTML = `<h2>${movie.title}</h2><p> ${movie.description}</p>`

        div.appendChild(ujdiv)
    })
})