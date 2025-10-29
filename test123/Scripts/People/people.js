

$(document).ready(function () {
    $("#addForm").submit(function (event) {
        event.preventDefault();

        var newPerson = {
            Name: $("#nameInput").val();
};

        $.ajax({
            url: '/People/Add',
            type: 'POST',
            data: { Name: name },
            success: function (newPerson) {
                $("#peopleTable tbody").append(
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
var btnclick = function (event) {
       
       
alert("Button geklickt"); };