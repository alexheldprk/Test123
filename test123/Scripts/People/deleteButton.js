// ---Eintrag Löschen---

$(document).on("click", ".deleteButton", function () {
    var row = $(this).closest("tr");
    var id = row.data("id");

    if (!confirm("Diesen Eintrag wirklich löschen?")) {
        return;
    }

    $.ajax({
        url: '/People/Delete',
        type: 'POST',
        data: { Id: id },
        success: function (response) {
            if (response.success) {
                row.remove();
            } else {
                alert("Fehler: " + response.message);
            }
        },
        error: function () {
            alert("Fehler beim Lesen!")
        }
    });
});