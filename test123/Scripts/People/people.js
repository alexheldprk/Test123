$(document).ready(function () {

    /*Formular befüllen*/

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
});

/*Testbutton*/

    var btnclick = function (event) {


        alert("Button geklickt");
    }