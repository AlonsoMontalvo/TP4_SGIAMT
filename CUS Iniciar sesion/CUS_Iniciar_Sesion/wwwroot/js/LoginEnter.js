
$(document).ready(function () {

    $("#btnusu").click(getupdate);

});


var getupdate = function () {
    var dni = document.getElementById('Dni').value;
    var estado = document.getElementById('Contra').value;
    $.ajax({
        url: "/Account/Login",
        type: "GET",
        data: { dni: dni, contra: estado },
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