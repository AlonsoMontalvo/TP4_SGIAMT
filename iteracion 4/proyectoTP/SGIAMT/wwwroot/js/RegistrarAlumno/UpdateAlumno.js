
$(document).ready(function () {

    $("#btnusu").click(getupdate);

});


var getupdate = function () {
    var dni = document.getElementById('dni').value;
    var estado = document.getElementById('estado').value;
    $.ajax({
        url: "/TNivelxTipoNivels/Modificarusuario",
        type: "GET",
        data: { iddni: dni, est: estado },
        contentType: "application/json; charset=utf-8",
        success: function () {
            //data is your result from controller
            if (data.success) {
                alert(data.message);
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
};