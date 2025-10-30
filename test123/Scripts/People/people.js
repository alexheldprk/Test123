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
                $("#peopleTable tbody").append(
                    "<tr><td>" + newPerson.Id + "</td><td>" + newPerson.Name + "</td></tr>"
                );
                $("#nameInput").val("");
            },
            error: function () {
                alert("Fehler beim Hinzufügen!")
            }
        });
    });


    var btnclick = function (event) {


        alert("Button geklickt");
    }

});