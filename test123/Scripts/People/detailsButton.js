$(document).ready(function () {

    /*Formular aufruf*/

    $("#peopleTable").on("click", ".detailsButton", function () {
        console.log("Details-button wurde geklickt");
        var $row = $(this).closest("tr");
        var id = $row.data("id");
        var name = $row.find(".nameCell").text();

        $("#detailId").text(id);
        $("#detailName").text(name);

        var modal = new bootstrap.Modal(document.getElementById('detailsModal'));
        modal.show();

    });
})
