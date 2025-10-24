$(document).ready(function () {
    $("#addform").submit(function (event) {
        event.preventDefault();

        var name = $("#nameinput").val();

        $.ajax({
            url: '/People/Add',
            type: 'POST',
            data: { name: name },
            success: function (newPerson) {
                $("#peopleTable").append(
                    "<tr><td>" + newPerson.Id + "<td><td>" + newPerson.Name + "<td><tr>"
                );
                $("#nameInput").val("");
            },
            error: function () {
                alert("Fehler beim Hinzufügen!")
            }
        });
    });
});