let form = document.getElementById("form");
let img = document.getElementById("image");
let url = "https://localhost:5001/api/actor";
let tr = document.getElementById("tr");




fetch(url)
    .then(res => res.json())
    .then(data => {
        data.forEach(el => {
            tr.innerHTML = `
            <td class="pt-5 fw-bold">${el.FullName}</td>
                    <td><img id="image" src="${el.ImageUrl}"
                            style="max-width:100px" draggable="false" /></td>
                    <td class="pt-5">
                        <a href="edit.html" class="btn btn-warning">Edit</a>
                        <a href="#" class="btn btn-danger btn-sweet-delete">Delete</a>
                    </td>
            `
        });
    })