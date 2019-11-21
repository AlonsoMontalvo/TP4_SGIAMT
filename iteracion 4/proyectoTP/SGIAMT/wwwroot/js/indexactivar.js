
$(document).ready(function () {

    $("#activar").click(getupdate);

});


var getupdate = function () {
    var dni = document.getElementById('activar').value;
 
    $.ajax({
        url: "/TUsuarios/Activo",
        type: "GET",
        data: { dni: dni },
        contentType: "application/json; charset=utf-8",
        success: function () {
            //data is your result from controller
            if (data.success) {
                //localStorage.setItem('dni', data.dni);
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
};