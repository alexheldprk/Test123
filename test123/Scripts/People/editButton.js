$(document).ready(function () {

    /*Formular aufruf*/

    $("#peopleTable").on("click", ".editButton", function () {
        console.log("Edit-button wurde geklickt");
        var $row = $(this).closest("tr");
        var id = $row.data("id");
        var name = $row.find(".nameCell").text();

        $row.find(".nameCell").html('<input type="text" class="editName" value="' + name + '" />');
        $(this).text("Speichern").removeClass("editButton").addClass("saveButton");
    });


    /*Formular bearbeiten*/

    $("#peopleTable").on("click", ".saveButton", function () {
        var $row = $(this).closest("tr");
        var id = $row.data("id");
        var newName = $row.find(".editName").val().trim();

        if (newName === "") {
            alert("Name darf nicht leer sein!");
            return;
        }

        /*Formular absenden*/

        $.ajax({
            url: '/People/Edit',
            type: 'POST',
            data: { Id: id, Name: newName },
            success: function (updatedPerson) {
                if (updatedPerson.error) {
                    alert(updatedPerson.error);
                    return;
                }

                $row.find(".nameCell").text(updatedPerson.Name);
                $row.find(".saveButton").text("Bearbeiten").removeClass("saveButton").addClass("editButton");
            },
            error: function () {
                alert("Fehler beim bearbeiten!");
            }
        });
    });

});