$(document).ready(function () {


    /*Formular einreichen*/

    $("#addForm").submit(function (event) {
        event.preventDefault();

        var newName = $("#nameInput").val().trim();
        if (newName === "") {
            alert("Name darf nicht leer sein!");
            return;
        }

        /*Formular absenden*/

        $.ajax({
            url: '/People/Add',
            type: 'POST',
            data: { Name: newName },
            success: function (newPerson) {
                $("#peopleTable tbody").append(`
                    <tr data-id="${newPerson.Id}">
                        <td>${newPerson.Id}</td>
                        <td class="nameCell">${newPerson.Name}</td>
                        <td>
                            <button type="button" class="editButton">Bearbeiten</button>
                            <button type="button" class="detailsButton">Details</button>
                            <button type="button" class="deleteButton">Löschen</button>
                        </td>
                    </tr>
                `);
                $("#nameInput").val("");
            },
            error: function () {
                alert("Fehler beim Hinzufügen!")
            }
        });
    });


    $.ajax({
        url: '/People/GetAll',
        type: 'POST',
        //data: { Name: newName },
        success: function (plist) {

            var tbody = $("#peopleTable tbody");
            for (var i = 0; i < plist.length; i++) {

                tbody.append(`
                    <tr data-id="${plist[i].Id}">
                        <td>${plist[i].Id}</td>
                        <td class="nameCell">${plist[i].Name}</td>
                        <td>
                            <button type="button" class="editButton">Bearbeiten</button>
                            <button type="button" class="detailsButton">Details</button>
                            <button type="button" class="deleteButton">Löschen</button>
                        </td>
                    </tr>
                `);
            }           
        },
        error: function () {
            alert("Fehler beim Lesen!")
        }
    });
});


//// ---Eintrag Löschen---

//$(document).on("click", ".deleteButton", function () {
//    var row = $(this).closest("tr");
//    var id = row.data("id");

//    if (!confirm("Diesen Eintrag wirklich löschen?")) {
//        return;
//    }

//    $.ajax({
//        url: '/People/Delete',
//        type: 'POST',
//        data: { Id: id },
//        success: function (response) {
//            if (response.success) {
//                row.remove();
//            } else {
//                alert("Fehler: " + response.message);
//            }       
//        },
//        error: function () {
//            alert("Fehler beim Lesen!")
//        }
//    });
//});



/*Testbutton*/

    var btnclick = function (event) {


        alert("Button geklickt");
    }