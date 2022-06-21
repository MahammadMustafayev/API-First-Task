let form = document.getElementById("form");
let img = document.getElementById("image");
let url = "https://localhost:5001/api/actor";
let row = document.querySelector(".row");


form.addEventListener("submit", function (e) {
    e.preventDefault();

    const data = {
        FullName: $('#name').val(),
        ImageUrl: $('#image').val()
    }
    $.ajax({
        url: `${url}create`,
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: "application/json",
        success: function (d) {
            $('#name').val('');
            $('#image').val('');
        },
        error: function () {
            console.log("Error var");
        }
    });
});

fetch(url)
    .then(res => res.json())
    .then(data => {
        data.forEach(el => {
            row.innerHTML = `
            <div class="col-md-4">
            <div style="width: 250px;">
                <img src="${el.imageUrl}" width="150" height="200" class="card-img" alt="">
                <div class="card-body">
                    <h3 class="text-uppercase text-primary">${el.fullName}</h3>
                </div>
            </div>
        </div>
            `
        });
    })